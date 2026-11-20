using System;
using System.Reflection;
using UnityEngine.UIElements;

#if UNITY_6000_5_OR_NEWER
using Unity.Scripting.LifecycleManagement;
#endif

namespace AssetCacheCleaner {
#if UNITY_6000_5_OR_NEWER
    [NoAutoStaticsCleanup]
#endif
    internal readonly struct BaseFieldReflection<T> {
        static readonly ReflectionType _type = new(typeof(BaseField<T>));

        // ReSharper disable once StaticMemberInGenericType
        static readonly ReflectionProperty _visualInputProperty =
            new(Type, "visualInput", BindingFlags.Instance | BindingFlags.NonPublic);

        public static Type Type => _type.Type;
        public static bool IsValid => _type.IsValid && _visualInputProperty.IsValid;
        public static bool IsSupported(Type type) => type != null && IsValid && Type.IsAssignableFrom(type);

        readonly object _instance;

        public BaseFieldReflection(object instance) {
            if (instance == null)
                throw new ArgumentNullException(nameof(instance));

            var type = instance.GetType();
            if (!IsSupported(type))
                throw new ArgumentException($"{Type.FullName} is not assignable from {type.FullName}.");

            _instance = instance;
        }

        public VisualElement VisualInput {
            get => (VisualElement)_visualInputProperty.GetValue(_instance);
            set => _visualInputProperty.SetValue(_instance, value);
        }
    }
}