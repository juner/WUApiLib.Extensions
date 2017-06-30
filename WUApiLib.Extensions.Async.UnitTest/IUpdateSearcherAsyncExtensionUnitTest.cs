using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using WUApiLib.Utility;
using WUApiLib.Utility.Extensions;
using static WUApiLib.Extensions.Async.UnitTest.ToString;

namespace WUApiLib.Extensions.Async.UnitTest
{
    [TestClass]
    public class IUpdateSearcherAsyncExtensionUnitTest
    {
        CancellationTokenSource TokenSource;
        [TestInitialize]
        public void Initialize()
        {
            TokenSource = new CancellationTokenSource();
        }
        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                TokenSource?.Cancel();
                TokenSource?.Dispose();
            }
            catch (Exception) { }
        }
        [TestMethod]
        [DataRow("Type != 'Driver'")]
        [DataRow(null)]
        public async Task SearchAsyncTest(string criteria)
        {
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                Debug.WriteLine("SEARCH START.");
                var Result = string.IsNullOrEmpty(criteria)
                    ? await Searcher.SearchAsync(TokenSource.Token)
                    : await Searcher.SearchAsync(criteria, TokenSource.Token);
                Debug.WriteLine("SEARCH STOP.");
                Debug.WriteLine($"SEARCH RESULT: {ISearchResultToString(Result)}");
                Debug.WriteLine("SEARCH RESULT ALL OUTPUT START.");
                foreach (var Update in Result.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE: {IUpdateToString(Update)}");
                Debug.WriteLine("SEARCH RESULT ALL OUTPUT STOP.");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}(0x{(uint)state:x}) {state.GetDescription()}");
                throw;
            }
        }
        [TestMethod]
        [DataRow("Type != 'Driver'")]
        [DataRow(null)]
        public async Task SearchAsyncCancelTest(string criteria)
        {
            var Token = CancellationTokenSource.CreateLinkedTokenSource(TokenSource.Token,
                new CancellationTokenSource(TimeSpan.FromSeconds(5)).Token).Token;
            var exception = await Assert.ThrowsExceptionAsync<TaskCanceledException>(async () =>
            {
                try
                {
                    var Session = new UpdateSession();
                    var Searcher = Session.CreateUpdateSearcher();
                    var Result = string.IsNullOrEmpty(criteria)
                        ? await Searcher.SearchAsync(Token)
                        : await Searcher.SearchAsync(criteria, Token);
                }
                catch (COMException e)
                {
                    var state = e.GetWindowsUpdateHResult();
                    if (Enum.IsDefined(state.GetType(), state))
                        Assert.Fail($"ERROR: {state}(0x{(uint)state:x}) {state.GetDescription()}");
                    throw;
                }
            });
            Assert.AreEqual(exception.CancellationToken, Token);
        }
    }
}
