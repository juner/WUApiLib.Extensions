using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Diagnostics;
using static WUApiLib.Extensions.Async.UnitTest.ToString;
using static WUApiLib.Extensions.Async.UnitTest.Utility;
using System.Runtime.InteropServices;
using WUApiLib.Utility.Extensions;
using WUApiLib.Utility;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace WUApiLib.Extensions.Async.UnitTest
{
    [TestClass]
    public class IUpdateDownloaderAsyncExtensionUnitTest
    {
        CancellationTokenSource TokenSource;
        [TestInitialize]
        public void Initialize()
        {
            TokenSource = new CancellationTokenSource();
        }
        public static ISet<HResult> Inconclusives = ImmutableHashSet.Create(new[] {
            HResult.WU_E_NO_UPDATE,
        });
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
        public async Task DownloadAsyncTest1()
        {
            if (!IsInRoleAdministrator())
                Assert.Inconclusive("user isn't in role administrator");
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                var SearchResult = await Searcher.SearchAsync("IsInstalled=0");
                var DownloadableUpdate = SearchResult.Updates.Cast<IUpdate>()
                    .Where(u => !u.IsDownloaded).Take(2);
                var Downloader = Session.CreateUpdateDownloader();
                Downloader.Updates = DownloadableUpdate.AddBundle().ToUpdateCollection();
                foreach (var Update in Downloader.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE {IUpdateToString(Update)}");
                Downloader.IsForced = true;
                var DownloadResult = await Downloader.DownloadAsync(p => Debug.WriteLine($"PROGRESS: {IDownloadProgressToString(p)}"), TokenSource.Token);
                Debug.WriteLine($"RESULT: {IDownloadResultToString(DownloadResult)}");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Inconclusives.Contains(state))
                    Assert.Inconclusive($"{state}(0x{(uint)state:x}) {state.GetDescription()}");
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}(0x{(uint)state:x}) {state.GetDescription()}");
                throw;
            }
        }
        [TestMethod]
        public async Task DownloadAsyncTest2()
        {
            if (!IsInRoleAdministrator())
                Assert.Inconclusive("user isn't in role administrator");
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                var SearchResult = await Searcher.SearchAsync("IsInstalled=0");
                var DownloadableUpdate = SearchResult.Updates.Cast<IUpdate>()
                    .Where(u => !u.IsDownloaded).Take(1);
                var Downloader = Session.CreateUpdateDownloader();
                Downloader.Updates = DownloadableUpdate.AddBundle().ToUpdateCollection();
                foreach (var Update in Downloader.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE {IUpdateToString(Update)}");
                Downloader.IsForced = true;
                var DownloadResult = await Downloader.DownloadAsync(TokenSource.Token);
                Debug.WriteLine($"RESULT: {IDownloadResultToString(DownloadResult)}");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Inconclusives.Contains(state))
                    Assert.Inconclusive($"{state}(0x{(uint)state:x}) {state.GetDescription()}");
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}(0x{(uint)state:x}) {state.GetDescription()}");
                throw;
            }
        }
    }
}
