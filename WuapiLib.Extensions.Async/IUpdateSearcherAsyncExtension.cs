using System;
using System.Threading;
using System.Threading.Tasks;

namespace WUApiLib.Extensions.Async
{
    public static class IUpdateSearcherAsyncExtension
    {
        /// <summary>
        /// アップデートの検索を非同期に行う
        /// </summary>
        /// <param name="searcher"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<ISearchResult> SearchAsync(this IUpdateSearcher searcher, CancellationToken cancellationToken = default(CancellationToken)) => SearchAsync(searcher, null, cancellationToken);
        /// <summary>
        /// アップデートの検索を非同期に行う
        /// </summary>
        /// <param name="searcher"></param>
        /// <param name="criteria"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<ISearchResult> SearchAsync(this IUpdateSearcher searcher, string criteria, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = new TaskCompletionSource<ISearchResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                task.TrySetCanceled(cancellationToken);
                return task.Task;
            }
            var job = null as ISearchJob;
            var reg = null as IDisposable;
            job = searcher.BeginSearch(criteria, new SearchCompletedCallback((_job, args) =>
            {
                try
                {
                    try
                    {
                        task.TrySetResult(searcher.EndSearch(_job));
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
        /// 検索完了時のコールバックの実装
        /// </summary>
        internal class SearchCompletedCallback : ISearchCompletedCallback
        {
            Action<ISearchJob, ISearchCompletedCallbackArgs> Action;
            public SearchCompletedCallback(Action<ISearchJob, ISearchCompletedCallbackArgs> Action) => this.Action = Action;
            public void Invoke(ISearchJob searchJob, ISearchCompletedCallbackArgs callbackArgs) => Action?.Invoke(searchJob, callbackArgs);
        }
    }
}
