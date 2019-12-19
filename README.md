# WUApiLib.Extensions

[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/juner/WUApiLib.Extensions/blob/master/LICENSE)

WUApiLib s Search/Download/Update 's Async Method Extension.

## use

- [Nuget package: WUApiLib.Extensions][WUApiLib.Extensions]
- [Nuget package: WUApiLib.Extensions.Async][WUApiLib.Extensions.Async]
- [Nuget package: WUApiLib.Utility][WUApiLib.Utility]

 [WUApiLib.Extensions.Async]: https://www.nuget.org/packages/WUApiLib.Extensions.Async/
 [WUApiLib.Extensions]: https://www.nuget.org/packages/WUApiLib.Extensions/
 [WUApiLib.Utility]: https://www.nuget.org/packages/WUApiLib.Utility/

## WUApiLib.Extensions 's extensions

- IEnumerable\<IUpdate>.ToUpdateCollection()
- IEnumerable\<IUpdate>.AddBundle()

## WUApiLib.Extensions.Async 's extensions

- Task\<IDownloadResult> IUpdateDownloader.DownloadAsync(CancellationToken = default)
- Task\<IDownloadResult> IUpdateDownloader.DownloadAsync(Action\<IDownloadProgress>, CancellationToken = default)
- Task\<IInstallationResult> IUpdateInstaller.InstallAsync(CancellationToken = default)
- Task\<IInstallationResult>  IUpdateInstaller.InstallAsync(Action\<IInstallationProgress>, CancellationToken = default)
- Task\<IInstallationResult>  IUpdateInstaller.UninstallAsync(CancellationToken = default)
- Task\<IInstallationResult>  IUpdateInstaller.UninstallAsync(Action\<IInstallationProgress>, CancellationToken = default)
- Task\<ISearchResult> IUpdateSearcher.SearchAsync(CancellationToken = default)
- Task\<ISearchResult> IUpdateSearcher.SearchAsync(string, CancellationToken = default)

## WUApiLib.Utility 's extensions

- WUApiLib.Utility.HResult COMException.GetWindowsUpdateHResult()

### WUApiLib.Utility.HResult

WUApiLib 's Success and ErrorCode

- [Appendix G: Windows Update Agent Result Codes](https://docs.microsoft.com/en-us/security-updates/windowsupdateservices/18128076)
- [WUA Success and Error Codes](https://docs.microsoft.com/en-us/windows/win32/wua_sdk/wua-success-and-error-codes-)
