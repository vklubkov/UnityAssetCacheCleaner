#if !UNITY_6000_6_OR_NEWER

using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class BaseBoolFieldExtensions {
        [NotNull] public static T WithOnLabelElement<T>([NotNull] this T element, [CanBeNull] Action<Label> callback)
                where T : BaseBoolField {
            callback?.Invoke(element.labelElement);
            return element;
        }

        [NotNull] public static T WithOnLabelElement<T>(
            [NotNull] this T element,
            [CanBeNull] Action<T, Label> callback)
                where T : BaseBoolField {
            callback?.Invoke(element, element.labelElement);
            return element;
        }

        [NotNull] public static T WithOnLabelElement<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<Label, TData> callback)
                where T : BaseBoolField {
            callback?.Invoke(element.labelElement, data);
            return element;
        }

        [NotNull] public static T WithOnLabelElement<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, Label, TData> callback)
                where T : BaseBoolField {
            callback?.Invoke(element, element.labelElement, data);
            return element;
        }
    }
}

#endif