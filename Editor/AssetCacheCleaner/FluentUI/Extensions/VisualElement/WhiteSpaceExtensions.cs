using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithWhiteSpace<T>([NotNull] this T element, StyleEnum<WhiteSpace> whiteSpace)
                where T : VisualElement {
            element.style.whiteSpace = whiteSpace;
            return element;
        }
    }
}