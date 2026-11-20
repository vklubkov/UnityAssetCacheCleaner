using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithCondition<T>(
            [NotNull] this T element,
            bool condition,
            [CanBeNull] Action<T> onTrue = null,
            [CanBeNull] Action<T> onFalse = null)
                where T : VisualElement {
            if (condition)
                onTrue?.Invoke(element);
            else
                onFalse?.Invoke(element);

            return element;
        }

        [NotNull] public static T WithCondition<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            bool condition,
            [CanBeNull] Action<T, TData> onTrue = null,
            [CanBeNull] Action<T, TData> onFalse = null)
                where T : VisualElement {
            if (condition)
                onTrue?.Invoke(element, data);
            else
                onFalse?.Invoke(element, data);

            return element;
        }

        [NotNull] public static T WithCondition<T>(
            [NotNull] this T element,
            [CanBeNull] Func<T, bool> condition,
            [CanBeNull] Action<T> onTrue = null,
            [CanBeNull] Action<T> onFalse = null)
                where T : VisualElement {
            if (condition?.Invoke(element) ?? true)
                onTrue?.Invoke(element);
            else
                onFalse?.Invoke(element);

            return element;
        }

        [NotNull] public static T WithCondition<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Func<T, TData, bool> condition,
            [CanBeNull] Action<T, TData> onTrue = null,
            [CanBeNull] Action<T, TData> onFalse = null)
                where T : VisualElement {
            if (condition?.Invoke(element, data) ?? true)
                onTrue?.Invoke(element, data);
            else
                onFalse?.Invoke(element, data);

            return element;
        }
    }
}