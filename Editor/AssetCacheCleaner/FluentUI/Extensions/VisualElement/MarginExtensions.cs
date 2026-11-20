using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithMarginLeft<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginLeft = margin;
            return element;
        }

        [NotNull] public static T WithMarginRight<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginRight = margin;
            return element;
        }

        [NotNull] public static T WithMarginTop<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginTop = margin;
            return element;
        }

        [NotNull] public static T WithMarginBottom<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginBottom = margin;
            return element;
        }

        public static T WithMargin<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginLeft = margin;
            element.style.marginRight = margin;
            element.style.marginTop = margin;
            element.style.marginBottom = margin;
            return element;
        }

        [NotNull] public static T WithMarginLeftRight<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginLeft = margin;
            element.style.marginRight = margin;
            return element;
        }

        [NotNull] public static T WithMarginLeftRight<T>(
            [NotNull] this T element,
            StyleLength left,
            StyleLength right)
                where T : VisualElement {
            element.style.marginLeft = left;
            element.style.marginRight = right;
            return element;
        }

        [NotNull] public static T WithMarginTopBottom<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginTop = margin;
            element.style.marginBottom = margin;
            return element;
        }

        [NotNull] public static T WithMarginTopBottom<T>(
            [NotNull] this T element,
            StyleLength top,
            StyleLength bottom)
                where T : VisualElement {
            element.style.marginTop = top;
            element.style.marginBottom = bottom;
            return element;
        }

        [NotNull] public static T WithMarginTopLeft<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginTop = margin;
            element.style.marginLeft = margin;
            return element;
        }

        [NotNull] public static T WithMarginTopLeft<T>(
            [NotNull] this T element,
            StyleLength top,
            StyleLength left)
                where T : VisualElement {
            element.style.marginTop = top;
            element.style.marginLeft = left;
            return element;
        }

        [NotNull] public static T WithMarginTopRight<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginTop = margin;
            element.style.marginRight = margin;
            return element;
        }

        [NotNull] public static T WithMarginTopRight<T>(
            [NotNull] this T element,
            StyleLength top,
            StyleLength right)
                where T : VisualElement {
            element.style.marginTop = top;
            element.style.marginRight = right;
            return element;
        }

        [NotNull] public static T WithMarginBottomLeft<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginBottom = margin;
            element.style.marginLeft = margin;
            return element;
        }

        [NotNull] public static T WithMarginBottomLeft<T>(
            [NotNull] this T element,
            StyleLength bottom,
            StyleLength left)
                where T : VisualElement {
            element.style.marginBottom = bottom;
            element.style.marginLeft = left;
            return element;
        }

        [NotNull] public static T WithMarginBottomRight<T>([NotNull] this T element, StyleLength margin)
                where T : VisualElement {
            element.style.marginBottom = margin;
            element.style.marginRight = margin;
            return element;
        }

        [NotNull] public static T WithMarginBottomRight<T>(
            [NotNull] this T element,
            StyleLength bottom,
            StyleLength right)
                where T : VisualElement {
            element.style.marginBottom = bottom;
            element.style.marginRight = right;
            return element;
        }

        [NotNull] public static T WithMargin<T>(
            [NotNull] this T element,
            StyleLength leftRight,
            StyleLength topBottom)
                where T : VisualElement {
            element.style.marginLeft = leftRight;
            element.style.marginRight = leftRight;
            element.style.marginTop = topBottom;
            element.style.marginBottom = topBottom;
            return element;
        }

        [NotNull] public static T WithMargin<T>(
            [NotNull] this T element,
            StyleLength left,
            StyleLength right,
            StyleLength top,
            StyleLength bottom)
                where T : VisualElement {
            element.style.marginLeft = left;
            element.style.marginRight = right;
            element.style.marginTop = top;
            element.style.marginBottom = bottom;
            return element;
        }
    }
}