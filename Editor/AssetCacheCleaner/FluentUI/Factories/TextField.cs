using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static TextField TextField() => new();
        [NotNull] public static TextField TextField(string label) => new(label);

        [NotNull] public static TextField TextField(
            int maxLength, bool multiline, bool isPasswordField, char maskChar) =>
                new(maxLength, multiline, isPasswordField, maskChar);

        [NotNull] public static TextField TextField(
            string label, int maxLength, bool multiline, bool isPasswordField, char maskChar) =>
                new(label, maxLength, multiline, isPasswordField, maskChar);
    }
}