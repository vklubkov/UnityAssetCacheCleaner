using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class BaseFieldExtensions {
        /// Sets the visualInput. Uses reflection.
        /// A workaround is to specify the visual input in the constructor.
        [NotNull] public static T WithVisualInput<T, TValue>(
            [NotNull] this T element,
            [CanBeNull] VisualElement visualInput)
                where T : BaseField<TValue> {
            if (BaseFieldReflection<TValue>.IsSupported(element.GetType()))
                new BaseFieldReflection<TValue>(element).VisualInput = visualInput;

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T, TValue>(
            [NotNull] this T element,
            [CanBeNull] Action<VisualElement> callback)
                where T : BaseField<TValue> {
            var visualInput = element.GetVisualInput<T, TValue>();
            if (visualInput != null)
                callback?.Invoke(visualInput);

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T, TValue>(
            [NotNull] this T element,
            [CanBeNull] Action<T, VisualElement> callback)
                where T : BaseField<TValue> {
            var visualInput = element.GetVisualInput<T, TValue>();
            if (visualInput != null)
                callback?.Invoke(element, visualInput);

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T, TData, TValue>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<VisualElement, TData> callback)
                where T : BaseField<TValue> {
            var visualInput = element.GetVisualInput<T, TValue>();
            if (visualInput != null)
                callback?.Invoke(visualInput, data);

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T, TData, TValue>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, VisualElement, TData> callback)
                where T : BaseField<TValue> {
            var visualInput = element.GetVisualInput<T, TValue>();
            if (visualInput != null)
                callback?.Invoke(element, visualInput, data);

            return element;
        }

        static VisualElement GetVisualInput<T, TValue>(this T element)
                where T : BaseField<TValue> =>
            BaseFieldReflection<TValue>.IsSupported(element.GetType())
                ? new BaseFieldReflection<TValue>(element).VisualInput
                : null;
    }
}