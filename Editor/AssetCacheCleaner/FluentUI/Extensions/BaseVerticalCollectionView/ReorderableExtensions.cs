using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class BaseVerticalCollectionViewExtensions {
        [NotNull] public static T AsReorderable<T>(
            [NotNull] this T element,
            bool reorderable = true)
                where T : BaseVerticalCollectionView {
            element.reorderable = reorderable;
            return element;
        }
    }
}