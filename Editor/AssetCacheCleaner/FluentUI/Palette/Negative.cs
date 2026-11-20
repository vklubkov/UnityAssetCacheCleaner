using UnityEditor;
using UnityEngine;
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable PartialTypeWithSinglePart

namespace AssetCacheCleaner {
    public static partial class Palette {
        public static partial class Hover {
            public static partial class Background {
                public static partial class Negative {
                    public static Color Color =>
                        EditorGUIUtility.isProSkin
                            ? DarkTheme.Hover.Background.Negative.Color
                            : LightTheme.Hover.Background.Negative.Color;
                }
            }
        }

        public static partial class Background {
            public static partial class Negative {
                public static Color Color =>
                    EditorGUIUtility.isProSkin
                        ? DarkTheme.Background.Negative.Color
                        : LightTheme.Background.Negative.Color;
            }
        }

        public static partial class DarkTheme {
            public static partial class Hover {
                public static partial class Background {
                    public static partial class Negative {
                        public static Color Color => new(0.6f, 0.2f, 0.2f);
                    }
                }
            }

            public static partial class Background {
                public static partial class Negative {
                    public static Color Color => new(0.5f, 0.1f, 0.1f);
                }
            }
        }


        public static partial class LightTheme {
            public static partial class Hover {
                public static partial class Background {
                    public static partial class Negative {
                        public static Color Color => new(1f, 0.5f, 0.5f);
                    }
                }
            }

            public static partial class Background {
                public static partial class Negative {
                    public static Color Color => new(1f, 0.6f, 0.6f);
                }
            }
        }
    }
}