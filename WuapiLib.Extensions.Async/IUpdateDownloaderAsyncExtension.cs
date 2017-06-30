using System;
using System.Threading;
using System.Threading.Tasks;

namespace WUApiLib.Extensions.Async
{
    public static class IUpdateDownloaderAsyncExtension
    {
        /// <summary>
        /// アップデートのダウンロードを非同期に行う
        /// </summary>
        /// <param name="downloader"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<IDownloadResult> DownloadAsync(this IUpdateDownloader downloader, CancellationToken cancellationToken = default(CancellationToken)) => DownloadAsync(downloader, null, cancellationToken);
        /// <summary>
        /// アップデートのダウンロードを非同期に行う
        /// </summary>
        /// <param name="downloader"></param>
        /// <param name="progress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<IDownloadResult> DownloadAsync(this IUpdateDownloader downloader, Action<IDownloadProgress> progress, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = new TaskCompletionSource<IDownloadResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                task.TrySetCanceled(cancellationToken);
                return task.Task;
            }
            var job = null as IDownloadJob;
            var reg = null as CancellationTokenRegistration?;
            job = downloader.BeginDownload(new DownloadProgressChangedCallback(progress),
                new DownloadCompletedCallback((_job2, args) =>
                {
                    try
                    {
                        try
                        {
                            task.TrySetResult(downloader.EndDownload(_job2));
                        }
                        catch (Exception e)
                        {
                            task.TrySetException(e);
                        }
                    }
                    finally
                    {
                        job = null;
                        reg?.Dispose();
                    }
                }), null);
            reg = cancellationToken.Register(() =>
            {
                task.TrySetCanceled(cancellationToken);
                job?.RequestAbort();
            });
            return task.Task;
        }
        /// <summary>
        /// ダウンロードプログレスの変更時コールバックの実装
        /// </summary>
        internal class DownloadProgressChangedCallback : IDownloadProgressChangedCallback
        {
            Action<IDownloadProgress> Action;
            public DownloadProgressChangedCallback(Action<IDownloadProgress> Action) => this.Action = Action;
            public void Invoke(IDownloadJob downloadJob, IDownloadProgressChangedCallbackArgs callbackArgs) => Action?.Invoke(callbackArgs.Progress);
        }
        /// <summary>
        /// ダウンロード終了時コールバックの実装
        /// </summary>
        internal class DownloadCompletedCallback : IDownloadCompletedCallback
        {
            Action<IDownloadJob, IDownloadCompletedCallbackArgs> Action;
            public DownloadCompletedCallback(Action<IDownloadJob, IDownloadCompletedCallbackArgs> Action) => this.Action = Action;
            public void Invoke(IDownloadJob downloadJob, IDownloadCompletedCallbackArgs callbackArgs) => Action?.Invoke(downloadJob, callbackArgs);
        }
    }
}
