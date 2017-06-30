using System;
using System.Threading;
using System.Threading.Tasks;

namespace WUApiLib.Extensions.Async
{
    public static class IUpdateInstallerAsyncExtension
    {
        /// <summary>
        /// アップデートのインストールを非同期に行う
        /// </summary>
        /// <param name="installer">インストーラ</param>
        /// <param name="cancellationToken">トークン</param>
        /// <returns></returns>
        public static Task<IInstallationResult> InstallAsync(this IUpdateInstaller installer, CancellationToken cancellationToken = default(CancellationToken)) => InstallAsync(installer, null, cancellationToken);
        /// <summary>
        /// アップデートのインストールを非同期に行う
        /// </summary>
        /// <param name="installer">インストーラ</param>
        /// <param name="progress">プログレス</param>
        /// <param name="cancellationToken">トークン</param>
        /// <returns></returns>
        public static Task<IInstallationResult> InstallAsync(this IUpdateInstaller installer, Action<IInstallationProgress> progress, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = new TaskCompletionSource<IInstallationResult>();
            if (cancellationToken.IsCancellationRequested)
            {
                task.TrySetCanceled(cancellationToken);
                return task.Task;
            }
            var job = null as IInstallationJob;
            var reg = null as IDisposable;
            job = installer.BeginInstall(new InstallationProgressChangeCallback(progress),
                new InstallationCompletedCallback((_job2, args) =>
                {
                    try
                    {
                        try
                        {
                            task.TrySetResult(installer.EndInstall(_job2));
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
        /// アップデートのアンインストールを非同期に行う
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<IInstallationResult> UninstallAsync(this IUpdateInstaller installer, CancellationToken cancellationToken = default(CancellationToken)) => UninstallAsync(installer, null, cancellationToken);
        /// <summary>
        /// アップデートのアンインストールを非同期に行う
        /// </summary>
        /// <param name="installer"></param>
        /// <param name="progress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static Task<IInstallationResult> UninstallAsync(this IUpdateInstaller installer, Action<IInstallationProgress> progress, CancellationToken cancellationToken = default(CancellationToken))
        {
            var task = new TaskCompletionSource<IInstallationResult>();
            var job = null as IInstallationJob;
            var reg = null as IDisposable;
            job = installer.BeginUninstall(new InstallationProgressChangeCallback(progress),
                new InstallationCompletedCallback((_job2, args) =>
                {
                    try
                    {
                        try
                        {
                            task.TrySetResult(installer.EndUninstall(job));
                        }
                        catch (Exception e)
                        {
                            task.TrySetException(e);
                        }
                    }
                    finally
                    {
                        job = null;
                        _job2?.CleanUp();
                        _job2 = null;
                        reg?.Dispose();
                        reg = null;
                    }
                }), null);
            reg = cancellationToken.Register(() =>
            {
                task.TrySetCanceled(cancellationToken);
                try
                {
                    if (job != null)
                        installer.EndUninstall(job);
                }
                catch (Exception e)
                {
                    task.TrySetException(e);
                }
            });
            return task.Task;
        }
        /// <summary>
        /// （アン）インストール処理の進捗更新時コールバック処理の実装
        /// </summary>
        internal class InstallationProgressChangeCallback : IInstallationProgressChangedCallback
        {
            Action<IInstallationProgress> Action;
            public InstallationProgressChangeCallback(Action<IInstallationProgress> Action) => this.Action = Action;
            public void Invoke(IInstallationJob installationJob, IInstallationProgressChangedCallbackArgs callbackArgs) => Action?.Invoke(callbackArgs.Progress);
        }
        /// <summary>
        /// （アン）インストール処理完了時コールバック処理の実装
        /// </summary>
        internal class InstallationCompletedCallback : IInstallationCompletedCallback
        {
            Action<IInstallationJob, IInstallationCompletedCallbackArgs> Action;
            public InstallationCompletedCallback(Action<IInstallationJob, IInstallationCompletedCallbackArgs> Action) => this.Action = Action;
            public void Invoke(IInstallationJob installationJob, IInstallationCompletedCallbackArgs callbackArgs) => Action?.Invoke(installationJob, callbackArgs);
        }
    }
}
