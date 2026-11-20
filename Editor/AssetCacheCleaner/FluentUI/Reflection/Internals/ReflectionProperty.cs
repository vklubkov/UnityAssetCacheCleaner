using System;
using System.Reflection;
using JetBrains.Annotations;
using static UnityEngine.Debug;

namespace AssetCacheCleaner {
    internal readonly struct ReflectionProperty {
        readonly string _fullName;
        readonly PropertyInfo _property;

        public bool IsValid {
            get {
                if (_property != null)
                    return true;

                LogError($"Property `{_fullName}` not found. Probably Unity internals have changed.");
                return false;
            }
        }

        public ReflectionProperty([NotNull] Type type, [NotNull] string name, BindingFlags bindingAttr) {
            _fullName = $"{type.FullName ?? ""}.{name}";
            _property = name == "" ? null : type.GetProperty(name, bindingAttr);
        }

        public object GetValue() => _property.GetValue(null);
        public object GetValue(object instance) => _property.GetValue(instance);
        public void SetValue(object value) => _property.SetValue(null, value);
        public void SetValue(object instance, object value) => _property.SetValue(instance, value);
    }
}