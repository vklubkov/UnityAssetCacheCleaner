using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T AsClear<T>([NotNull] this T element)
                where T : VisualElement {
            element.Clear();
            return element;
        }

        [NotNull] public static T AddTo<T, TParent>([NotNull] this T element, [NotNull] TParent parent)
                where T : VisualElement
                where TParent : VisualElement {
            parent.Add(element);
            return element;
        }

        [NotNull] public static T InsertInto<T, TParent>(
            [NotNull] this T element,
            [NotNull] TParent parent,
            int atIndex)
                where T : VisualElement
                where TParent : VisualElement {
            parent.Insert(atIndex, element);
            return element;
        }

        [NotNull] public static T Remove<T>([NotNull] this T element)
                where T : VisualElement {
            element.RemoveFromHierarchy();
            return element;
        }
    }
}