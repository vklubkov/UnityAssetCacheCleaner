using System;
using System.IO;
using JetBrains.Annotations;
using UnityEditor;

namespace AssetCacheCleaner {
    internal class Preferences {
        const string _editorPrefsAssetStoreCachePathKey = "AssetCacheCleaner_AssetStoreCachePath";
        const string _editorPrefsShowConfirmationPathKey = "AssetCacheCleaner_ShowConfirmation";
        const string _editorPrefsShowBannerPathKey = "AssetCacheCleaner_ShowBanner";

        string _cachedAssetStoreCachePath;
        bool? _cachedShowConfirmation;
        bool? _cachedShowBanner;

        public string AssetStoreCachePath {
            get => _cachedAssetStoreCachePath ??=
                EditorPrefs.GetString(_editorPrefsAssetStoreCachePathKey, PlatformDefaultAssetStoreCachePath);
            set {
                if (string.IsNullOrEmpty(value) || value == PlatformDefaultAssetStoreCachePath) {
                    EditorPrefs.DeleteKey(_editorPrefsAssetStoreCachePathKey);
                    _cachedAssetStoreCachePath = null;
                }
                else {
                    EditorPrefs.SetString(_editorPrefsAssetStoreCachePathKey, value);
                    _cachedAssetStoreCachePath = value;
                }
            }
        }

        public string PlatformDefaultAssetStoreCachePath {
            get {
#if UNITY_EDITOR_WIN
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appData, "Unity", "Asset Store-5.x");
#elif UNITY_EDITOR_OSX
                var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return Path.Combine(userProfile, "Library/Unity/Asset Store-5.x");
#elif UNITY_EDITOR_LINUX
                var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return Path.Combine(userProfile, ".local/share/unity3d/Asset Store-5.x");
#else
                return "";
#endif
            }
        }

        public bool ShowConfirmation {
            get => _cachedShowConfirmation ??= EditorPrefs.GetBool(_editorPrefsShowConfirmationPathKey, true);
            set {
                EditorPrefs.SetBool(_editorPrefsShowConfirmationPathKey, value);
                _cachedShowConfirmation = value;
            }
        }

        public bool ShowBanner {
            get => _cachedShowBanner ??= EditorPrefs.GetBool(_editorPrefsShowBannerPathKey, true);
            set {
                EditorPrefs.SetBool(_editorPrefsShowBannerPathKey, value);
                _cachedShowBanner = value;
            }
        }
    }
}