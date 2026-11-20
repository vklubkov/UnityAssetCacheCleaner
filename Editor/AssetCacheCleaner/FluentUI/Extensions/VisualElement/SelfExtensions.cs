using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithSelf<T>([NotNull] this T element, [CanBeNull] Action<T> callback)
                where T : VisualElement {
            callback?.Invoke(element);
            return element;
        }

        [NotNull] public static T WithSelf<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, TData> callback)
                where T : VisualElement {
            callback?.Invoke(element, data);
            return element;
        }
    }
}