using System.Collections.Generic;
using System.Linq;

namespace WUApiLib.Extensions
{
    public static class IUpdateExtension
    {
        /// <summary>
        /// to <see cref="UpdateCollection"/>
        /// </summary>
        /// <param name="Updates"></param>
        /// <returns></returns>
        public static UpdateCollection ToUpdateCollection(this IEnumerable<IUpdate> Updates)
        {
            return Updates.Aggregate(new UpdateCollection(), (uc, u) =>
            {
                uc.Add(u);
                return uc;
            });
        }
        /// <summary>
        /// add <see cref="IUpdate.BundledUpdates"/>'s <see cref="IUpdate"/>
        /// </summary>
        /// <param name="Updates"></param>
        /// <returns></returns>
        public static IEnumerable<IUpdate> AddBundle(this IEnumerable<IUpdate> Updates)
        {
            foreach (var Update in Updates)
            {
                foreach (var BundleUpdate in Update.BundledUpdates.Cast<IUpdate>())
                {
                    yield return BundleUpdate;
                }
                yield return Update;
            }
        }
    }
}
