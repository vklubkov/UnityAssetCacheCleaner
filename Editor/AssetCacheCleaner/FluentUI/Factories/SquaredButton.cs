using System;
using JetBrains.Annotations;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static SquaredButton SquaredButton() => new();
        [NotNull] public static SquaredButton SquaredButton(Action clickEvent) => new(clickEvent);

        [NotNull] public static SquaredButton SquaredButton(
            string text, Action clickEvent = null) =>
                new(text, clickEvent);
    }
}