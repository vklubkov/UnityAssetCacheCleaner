using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class BaseFieldExtensions {
        [NotNull] public static T WithOnLabelElement<T, TValue>(
            [NotNull] this T element,
            [CanBeNull] Action<Label> callback)
                where T : BaseField<TValue> {
            callback?.Invoke(element.labelElement);
            return element;
        }

        [NotNull] public static T WithOnLabelElement<T, TValue>(
            [NotNull] this T element,
            [CanBeNull] Action<T, Label> callback)
                where T : BaseField<TValue> {
            callback?.Invoke(element, element.labelElement);
            return element;
        }

        [NotNull] public static T WithOnLabelElement<T, TData, TValue>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<Label, TData> callback)
                where T : BaseField<TValue> {
            callback?.Invoke(element.labelElement, data);
            return element;
        }

        [NotNull] public static T WithOnLabelElement<T, TData, TValue>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, Label, TData> callback)
                where T : BaseField<TValue> {
            callback?.Invoke(element, element.labelElement, data);
            return element;
        }
    }
}