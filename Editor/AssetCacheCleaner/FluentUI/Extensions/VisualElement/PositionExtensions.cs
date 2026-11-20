using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithPosition<T>([NotNull] this T element, Position position)
                where T : VisualElement {
            element.style.position = position;
            return element;
        }

        [NotNull] public static T WithLeft<T>([NotNull] this T element, StyleLength left)
                where T : VisualElement {
            element.style.left = left;
            return element;
        }

        [NotNull] public static T WithRight<T>([NotNull] this T element, StyleLength right)
                where T : VisualElement {
            element.style.right = right;
            return element;
        }

        [NotNull] public static T WithTop<T>([NotNull] this T element, StyleLength top)
                where T : VisualElement {
            element.style.top = top;
            return element;
        }

        [NotNull] public static T WithBottom<T>([NotNull] this T element, StyleLength bottom)
                where T : VisualElement {
            element.style.bottom = bottom;
            return element;
        }
    }
}