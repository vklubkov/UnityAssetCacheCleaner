using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.color = color;
            return element;
        }

        [NotNull] public static T WithBackgroundColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.backgroundColor = color;
            return element;
        }
    }
}