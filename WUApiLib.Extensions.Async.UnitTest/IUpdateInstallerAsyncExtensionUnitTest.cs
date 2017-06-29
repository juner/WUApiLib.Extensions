using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using WUApiLib.Utility;
using WUApiLib.Utility.Extensions;
using static WUApiLib.Extensions.Async.UnitTest.ToString;
using static WUApiLib.Extensions.Async.UnitTest.Utility;
using System.Threading;

namespace WUApiLib.Extensions.Async.UnitTest
{
    [TestClass]
    public class IUpdateInstallerAsyncExtensionUnitTest
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
        public async Task InstallAsync1()
        {
            if (!IsInRoleAdministrator())
                Assert.Inconclusive("user isn't in role administrator");
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                var SearchResult = await Searcher.SearchAsync("IsInstalled=0");
                var InstallableUpdate = SearchResult.Updates.Cast<IUpdate>().Where(u => u.IsDownloaded).Take(1);
                var Installer = Session.CreateUpdateInstaller();
                Installer.Updates = InstallableUpdate.AddBundle().ToUpdateCollection();
                foreach (var Update in Installer.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE {IUpdateToString(Update)}");
                Installer.IsForced = true;
                var InstallResult = await Installer.InstallAsync(p => Debug.WriteLine($"PRGRESS: {IInstallationProgressToString(p)}"), TokenSource.Token);
                Debug.WriteLine($"RESULT: {IInstallationResultToString(InstallResult)}");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}({(uint)state}) {state.GetDescription()}");
                throw;
            }
        }
        [TestMethod]
        public async Task InstallAsync2()
        {
            if (!IsInRoleAdministrator())
                Assert.Inconclusive("user isn't in role administrator");
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                var SearchResult = await Searcher.SearchAsync("IsInstalled=0");
                var InstallableUpdate = SearchResult.Updates.Cast<IUpdate>().Where(u => u.IsDownloaded).Take(1);
                var Installer = Session.CreateUpdateInstaller();
                Installer.Updates = InstallableUpdate.AddBundle().ToUpdateCollection();
                foreach (var Update in Installer.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE {IUpdateToString(Update)}");
                Installer.IsForced = true;
                var InstallResult = await Installer.InstallAsync(TokenSource.Token);
                Debug.WriteLine($"RESULT: {IInstallationResultToString(InstallResult)}");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}({(uint)state}) {state.GetDescription()}");
                throw;
            }
        }
        [TestMethod]
        public async Task UnInstallAsync1()
        {
            if (!IsInRoleAdministrator())
                Assert.Inconclusive("user isn't in role administrator");
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                var SearchResult = await Searcher.SearchAsync("IsInstalled=1");
                var UninstallableUpdate = SearchResult.Updates.Cast<IUpdate>().Take(1);
                var Uninstaller = Session.CreateUpdateInstaller();
                Uninstaller.Updates = UninstallableUpdate.ToUpdateCollection();
                foreach (var Update in Uninstaller.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE {IUpdateToString(Update)}");
                Uninstaller.IsForced = true;
                var UninstallResult = await Uninstaller.UninstallAsync(p => Debug.WriteLine($"PRGRESS: {IInstallationProgressToString(p)}"), TokenSource.Token);
                Debug.WriteLine($"RESULT: {IInstallationResultToString(UninstallResult)}");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}({(uint)state}) {state.GetDescription()}");
                throw;
            }
        }
        [TestMethod]
        public async Task UnInstallAsync2()
        {
            if (!IsInRoleAdministrator())
                Assert.Inconclusive("user isn't in role administrator");
            try
            {
                var Session = new UpdateSession();
                var Searcher = Session.CreateUpdateSearcher();
                var SearchResult = await Searcher.SearchAsync("IsInstalled=1");
                var UninstallableUpdate = SearchResult.Updates.Cast<IUpdate>().Take(1);
                var Uninstaller = Session.CreateUpdateInstaller();
                Uninstaller.Updates = UninstallableUpdate.ToUpdateCollection();
                foreach (var Update in Uninstaller.Updates.Cast<IUpdate>())
                    Debug.WriteLine($"UPDATE {IUpdateToString(Update)}");
                Uninstaller.IsForced = true;
                var UninstallResult = await Uninstaller.UninstallAsync(TokenSource.Token);
                Debug.WriteLine($"RESULT: {IInstallationResultToString(UninstallResult)}");
            }
            catch (COMException e)
            {
                var state = e.GetWindowsUpdateHResult();
                if (Enum.IsDefined(state.GetType(), state))
                    Assert.Fail($"ERROR: {state}({(uint)state}) {state.GetDescription()}");
                throw;
            }
        }

    }
}
