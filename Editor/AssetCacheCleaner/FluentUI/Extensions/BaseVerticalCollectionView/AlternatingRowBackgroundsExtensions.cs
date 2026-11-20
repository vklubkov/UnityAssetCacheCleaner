using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class BaseVerticalCollectionViewExtensions {
        [NotNull] public static T WithAlternatingRowBackgrounds<T>(
            [NotNull] this T element,
            AlternatingRowBackground showAlternatingRowBackgrounds)
                where T : BaseVerticalCollectionView {
            element.showAlternatingRowBackgrounds = showAlternatingRowBackgrounds;
            return element;
        }
    }
}