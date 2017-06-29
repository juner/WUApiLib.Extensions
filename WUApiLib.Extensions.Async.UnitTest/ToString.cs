using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WUApiLib.Extensions.Async.UnitTest
{
    internal static class ToString
    {
        public static string IDownloadProgressToString(IDownloadProgress p)
        {
            return $"{nameof(p.PercentComplete)}:{p.PercentComplete}"
                + $", {nameof(p.TotalBytesDownloaded)}:{p.TotalBytesDownloaded}"
                + $", {nameof(p.TotalBytesToDownload)}:{p.TotalBytesToDownload}"
                + $", {nameof(p.CurrentUpdateBytesDownloaded)}:{p.CurrentUpdateBytesDownloaded}"
                + $", {nameof(p.CurrentUpdateBytesToDownload)}:{p.CurrentUpdateBytesToDownload}"
                + $", {nameof(p.CurrentUpdateDownloadPhase)}:{p.CurrentUpdateDownloadPhase}"
                + $", {nameof(p.CurrentUpdateIndex)}:{p.CurrentUpdateIndex}"
                + $", {nameof(p.CurrentUpdatePercentComplete)}:{p.CurrentUpdatePercentComplete}";
        }
        public static string IDownloadResultToString(IDownloadResult r)
        {
            return $"{nameof(r.HResult)}:{r.HResult}"
                + $", {nameof(r.ResultCode)}:{r.ResultCode}";
        }
        internal static string ISearchResultToString(ISearchResult s)
        {
            return $"{nameof(s.ResultCode)}:{s.ResultCode}";
        }
        internal static string IUpdateToString(IUpdate u)
        {
            return $"{nameof(IUpdate)}{{{nameof(u.Title)}:\"{u.Title}\""
                + $", {nameof(u.KBArticleIDs)}:[{string.Join(", ", u.KBArticleIDs.Cast<string>())}]"
                + $", {nameof(u.IsDownloaded)}:{u.IsDownloaded}"
                + $", {nameof(u.IsInstalled)}:{u.IsInstalled}}}";
        }
        internal static string IInstallationProgressToString(IInstallationProgress p)
        {
            return $"{nameof(p.PercentComplete)}:{p.PercentComplete}"
                + $", {nameof(p.CurrentUpdateIndex)}:{p.CurrentUpdateIndex}"
                + $", {nameof(p.CurrentUpdatePercentComplete)}:{p.CurrentUpdatePercentComplete}";
        }
        internal static string IInstallationResultToString(IInstallationResult r)
        {
            return $"{nameof(r.HResult)}:{r.HResult}"
                + $", {nameof(r.ResultCode)}:{r.ResultCode}"
                + $", {nameof(r.RebootRequired)}:{r.RebootRequired}";
        }
    }
}
