using System;
using JetBrains.Annotations;
using static UnityEngine.Debug;

namespace AssetCacheCleaner {
    internal readonly struct ReflectionType {
        readonly string _fullName;

        public Type Type { get; }

        public bool IsValid {
            get {
                if (Type != null)
                    return true;

                LogError($"Type `{_fullName}` not found. Probably Unity internals have changed.");
                return false;
            }
        }

        public ReflectionType([NotNull] Type type) {
            _fullName = type.FullName ?? "";
            Type = type;
        }

        public ReflectionType(
            [NotNull] string module,
            [NotNull] string fullName,
            [CanBeNull] Type fallbackType = null) {
            _fullName = fullName;
            Type = Type.GetType($"{fullName}, {module}") ?? fallbackType?.Assembly.GetType(fullName);
        }
    }
}