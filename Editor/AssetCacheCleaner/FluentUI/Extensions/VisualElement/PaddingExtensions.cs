using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithPaddingLeft<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingLeft = padding;
            return element;
        }

        [NotNull] public static T WithPaddingRight<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingRight = padding;
            return element;
        }

        [NotNull] public static T WithPaddingTop<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingTop = padding;
            return element;
        }

        [NotNull] public static T WithPaddingBottom<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingBottom = padding;
            return element;
        }

        [NotNull] public static T WithPaddingLeftRight<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingLeft = padding;
            element.style.paddingRight = padding;
            return element;
        }

        [NotNull] public static T WithPaddingLeftRight<T>(
            [NotNull] this T element,
            StyleLength left,
            StyleLength right)
                where T : VisualElement {
            element.style.paddingLeft = left;
            element.style.paddingRight = right;
            return element;
        }

        [NotNull] public static T WithPaddingTopBottom<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingTop = padding;
            element.style.paddingBottom = padding;
            return element;
        }

        [NotNull] public static T WithPaddingTopBottom<T>(
            [NotNull] this T element,
            StyleLength top,
            StyleLength bottom)
                where T : VisualElement {
            element.style.paddingTop = top;
            element.style.paddingBottom = bottom;
            return element;
        }

        [NotNull] public static T WithPaddingTopLeft<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingTop = padding;
            element.style.paddingLeft = padding;
            return element;
        }

        [NotNull] public static T WithPaddingTopLeft<T>(
            [NotNull] this T element,
            StyleLength top,
            StyleLength left)
                where T : VisualElement {
            element.style.paddingTop = top;
            element.style.paddingLeft = left;
            return element;
        }

        [NotNull] public static T WithPaddingTopRight<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingTop = padding;
            element.style.paddingRight = padding;
            return element;
        }

        [NotNull] public static T WithPaddingTopRight<T>(
            [NotNull] this T element,
            StyleLength top,
            StyleLength right)
                where T : VisualElement {
            element.style.paddingTop = top;
            element.style.paddingRight = right;
            return element;
        }

        [NotNull] public static T WithPaddingBottomLeft<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingBottom = padding;
            element.style.paddingLeft = padding;
            return element;
        }

        [NotNull] public static T WithPaddingBottomLeft<T>(
            [NotNull] this T element,
            StyleLength bottom,
            StyleLength left)
                where T : VisualElement {
            element.style.paddingBottom = bottom;
            element.style.paddingLeft = left;
            return element;
        }

        [NotNull] public static T WithPaddingBottomRight<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingBottom = padding;
            element.style.paddingRight = padding;
            return element;
        }

        [NotNull] public static T WithPaddingBottomRight<T>(
            [NotNull] this T element,
            StyleLength bottom,
            StyleLength right)
                where T : VisualElement {
            element.style.paddingBottom = bottom;
            element.style.paddingRight = right;
            return element;
        }

        [NotNull] public static T WithPadding<T>([NotNull] this T element, StyleLength padding)
                where T : VisualElement {
            element.style.paddingLeft = padding;
            element.style.paddingRight = padding;
            element.style.paddingTop = padding;
            element.style.paddingBottom = padding;
            return element;
        }

        [NotNull] public static T WithPadding<T>(
            [NotNull] this T element,
            StyleLength leftRight,
            StyleLength topBottom)
                where T : VisualElement {
            element.style.paddingLeft = leftRight;
            element.style.paddingRight = leftRight;
            element.style.paddingTop = topBottom;
            element.style.paddingBottom = topBottom;
            return element;
        }

        [NotNull] public static T WithPadding<T>(
            [NotNull] this T element,
            StyleLength left,
            StyleLength right,
            StyleLength top,
            StyleLength bottom)
                where T : VisualElement {
            element.style.paddingLeft = left;
            element.style.paddingRight = right;
            element.style.paddingTop = top;
            element.style.paddingBottom = bottom;
            return element;
        }
    }
}