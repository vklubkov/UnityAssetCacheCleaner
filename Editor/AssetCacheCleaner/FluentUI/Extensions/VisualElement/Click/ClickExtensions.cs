using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithOnClick<T>(
            [NotNull] this T element,
            [NotNull] EventCallback<ClickEvent> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown,
            bool once = false)
                where T : VisualElement {
            if (once)
                element.RegisterCallbackOnce(callback, useTrickleDown);
            else
                element.RegisterCallback(callback, useTrickleDown);

            return element;
        }

        [NotNull] public static T WithOnClick<T>(
            [NotNull] this T element,
            [NotNull] EventCallback<ClickEvent, T> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown,
            bool once = false)
                where T : VisualElement {
            if (once)
                element.RegisterCallbackOnce(callback, element, useTrickleDown);
            else
                element.RegisterCallback(callback, element, useTrickleDown);

            return element;
        }

        [NotNull] public static T WithOnClick<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [NotNull] EventCallback<ClickEvent, TData> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown,
            bool once = false)
                where T : VisualElement {
            if (once)
                element.RegisterCallbackOnce(callback, data, useTrickleDown);
            else
                element.RegisterCallback(callback, data, useTrickleDown);

            return element;
        }

        [NotNull] public static T WithOnClick<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [NotNull] EventCallback<ClickEvent, (T, TData)> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown,
            bool once = false)
                where T : VisualElement {
            if (once)
                element.RegisterCallbackOnce(callback, (element, data), useTrickleDown);
            else
                element.RegisterCallback(callback, (element, data), useTrickleDown);

            return element;
        }

        [NotNull] public static T WithoutOnClick<T>(
            [NotNull] this T element,
            [NotNull] EventCallback<ClickEvent> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown)
                where T : VisualElement {
            element.UnregisterCallback(callback, useTrickleDown);
            return element;
        }

        [NotNull] public static T WithoutOnClick<T>(
            [NotNull] this T element,
            [NotNull] EventCallback<ClickEvent, T> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown)
                where T : VisualElement {
            element.UnregisterCallback(callback, useTrickleDown);
            return element;
        }

        [NotNull] public static T WithoutOnClick<T, TData>(
            [NotNull] this T element,
            [NotNull] EventCallback<ClickEvent, TData> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown)
                where T : VisualElement {
            element.UnregisterCallback(callback, useTrickleDown);
            return element;
        }

        [NotNull] public static T WithoutOnClick<T, TData>(
            [NotNull] this T element,
            [NotNull] EventCallback<ClickEvent, (T, TData)> callback,
            TrickleDown useTrickleDown = TrickleDown.NoTrickleDown)
                where T : VisualElement {
            element.UnregisterCallback(callback, useTrickleDown);
            return element;
        }
    }
}