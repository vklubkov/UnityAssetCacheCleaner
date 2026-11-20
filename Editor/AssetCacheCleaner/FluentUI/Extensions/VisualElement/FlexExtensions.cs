using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithFlexShrink<T>([NotNull] this T element, StyleFloat flexShrink)
                where T : VisualElement {
            element.style.flexShrink = flexShrink;
            return element;
        }

        [NotNull] public static T WithFlexBasis<T>([NotNull] this T element, StyleLength flexBasis)
                where T : VisualElement {
            element.style.flexBasis = flexBasis;
            return element;
        }

        [NotNull] public static T WithFlexDirection<T>([NotNull] this T element, FlexDirection flexDirection)
                where T : VisualElement {
            element.style.flexDirection = flexDirection;
            return element;
        }

        [NotNull] public static T WithFlexGrow<T>([NotNull] this T element, StyleFloat flexGrow)
                where T : VisualElement {
            element.style.flexGrow = flexGrow;
            return element;
        }

        [NotNull] public static T WithFlexWrap<T>([NotNull] this T element, Wrap wrap)
                where T : VisualElement {
            element.style.flexWrap = wrap;
            return element;
        }

        [NotNull] public static T WithJustifyContent<T>([NotNull] this T element, Justify justifyContent)
                where T : VisualElement {
            element.style.justifyContent = justifyContent;
            return element;
        }

        [NotNull] public static T WithAlignItems<T>([NotNull] this T element, Align alignItems)
                where T : VisualElement {
            element.style.alignItems = alignItems;
            return element;
        }

        [NotNull] public static T WithAlignSelf<T>([NotNull] this T element, Align alignSelf)
                where T : VisualElement {
            element.style.alignSelf = alignSelf;
            return element;
        }

        [NotNull] public static T WithDisplay<T>([NotNull] this T element, DisplayStyle displayStyle)
                where T : VisualElement {
            element.style.display = displayStyle;
            return element;
        }

        [NotNull] public static T WithDisplay<T>([NotNull] this T element, bool display)
                where T : VisualElement {
            element.style.display = display ? DisplayStyle.Flex : DisplayStyle.None;
            return element;
        }
    }
}