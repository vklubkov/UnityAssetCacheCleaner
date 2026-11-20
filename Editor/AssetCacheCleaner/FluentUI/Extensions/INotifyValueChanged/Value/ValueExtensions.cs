using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    // ReSharper disable once InconsistentNaming
    public static partial class INotifyValueChangedExtensions {
        [NotNull] public static T WithValue<T, TValue>([NotNull] this T element, TValue value)
                where T : INotifyValueChanged<TValue> {
            element.value = value;
            return element;
        }

        [NotNull] public static T WithValueWithoutNotify<T, TValue>([NotNull, InstantHandle] this T element, TValue value)
                where T : INotifyValueChanged<TValue> {
            element.SetValueWithoutNotify(value);
            return element;
        }
    }
}