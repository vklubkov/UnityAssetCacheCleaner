using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithTooltip<T>([NotNull] this T element, [CanBeNull] string tooltip)
                where T : VisualElement {
            element.tooltip = tooltip;
            return element;
        }
    }
}