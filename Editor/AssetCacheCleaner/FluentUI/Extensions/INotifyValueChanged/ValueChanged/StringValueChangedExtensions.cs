using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    // ReSharper disable once InconsistentNaming
    public static partial class INotifyValueChangedExtensions {
        [NotNull] public static T WithOnValueChanged<T>(
            [NotNull] this T element,
            [NotNull] EventCallback<ChangeEvent<string>> callback)
                where T : INotifyValueChanged<string> {
            element.RegisterValueChangedCallback(callback);
            return element;
        }

        [NotNull] public static T WithOnValueChanged<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [NotNull] EventCallback<ChangeEvent<string>, TData> callback)
                where T : INotifyValueChanged<string> {
            // See UnityEngine.UIElements.INotifyValueChangedExtensions.RegisterValueChangedCallback
            if (element is not CallbackEventHandler callbackEventHandler)
                return element;

            callbackEventHandler.RegisterCallback(callback, data);
            return element;
        }

        [NotNull] public static T WithoutOnValueChanged<T>(
            [NotNull] this T element,
            [NotNull] EventCallback<ChangeEvent<string>> callback)
                where T : INotifyValueChanged<string> {
            element.UnregisterValueChangedCallback(callback);
            return element;
        }

        [NotNull] public static T WithoutOnValueChanged<T, TData>(
            [NotNull] this T element,
            [NotNull] EventCallback<ChangeEvent<string>, TData> callback)
                where T : INotifyValueChanged<string> {
            // See UnityEngine.UIElements.INotifyValueChangedExtensions.UnregisterValueChangedCallback
            if (element is not CallbackEventHandler callbackEventHandler)
                return element;

            callbackEventHandler.UnregisterCallback(callback);
            return element;
        }
    }
}