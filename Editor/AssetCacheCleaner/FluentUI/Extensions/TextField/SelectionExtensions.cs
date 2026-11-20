using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class TextFieldExtensions {
        [NotNull] public static T WithSelectAllOnFocus<T>([NotNull] this T element, bool value = true)
                where T : TextField {
            element.selectAllOnFocus = value;
            return element;
        }

        [NotNull] public static T WithSelectAllOnMouseUp<T>([NotNull] this T element, bool value = true)
                where T : TextField {
            element.selectAllOnMouseUp = value;
            return element;
        }

        [NotNull] public static T WithSelectRange<T>([NotNull] this T element, int cursorIndex, int selectionIndex)
            where T : TextField {
            element.SelectRange(cursorIndex, selectionIndex);
            return element;
        }

        [NotNull] public static T WithClearSelection<T>([NotNull] this T element)
            where T : TextField {
            element.SelectRange(0, 0);
            return element;
        }
    }
}