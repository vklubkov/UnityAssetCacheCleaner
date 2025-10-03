#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AssetCacheCleaner {
    internal class AssetCacheCleanerWindow : EditorWindow {
        const string _editorPrefsAssetStoreCachePathKey = "AssetCacheCleaner_AssetStoreCachePath";
        const string _editorPreShowConfirmationPathKey = "AssetCacheCleaner_ShowConfirmation";

        string _cachePath = string.Empty;
        bool _showConfirmation = true;

        readonly SortedList<string, (string Publisher, string Path)> _assets = new();
        Vector2 _scrollPosition = Vector2.zero;

        [MenuItem("Tools/Asset Cache Cleaner")]
        static void ShowWindow() {
            var window = GetWindow<AssetCacheCleanerWindow>();
            window.minSize = new Vector2(600, 200);
            window.titleContent = new GUIContent("Asset Cache Cleaner");
            window.UpdateAssetStoreCachePath();
            window.UpdateShowConfirmation();
            window.UpdatePackagesList();
        }

        void UpdateAssetStoreCachePath() {
            _cachePath = EditorPrefs.GetString(_editorPrefsAssetStoreCachePathKey);
            if (Directory.Exists(_cachePath))
                return;

#if UNITY_EDITOR_WIN
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _cachePath = Path.Combine(appData, "Unity", "Asset Store-5.x");
#elif UNITY_EDITOR_OSX
            // NOTE: not tested on OS X!
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _cachePath = Path.Combine(userProfile, "Library/Unity/Asset Store-5.x");
#elif UNITY_EDITOR_LINUX
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _cachePath = Path.Combine(userProfile, ".local/share/unity3d/Asset Store-5.x");
#endif
        }

        void UpdateShowConfirmation() =>
            _showConfirmation = EditorPrefs.GetBool(_editorPreShowConfirmationPathKey, true);

        void UpdatePackagesList() {
            if (!Directory.Exists(_cachePath))
                return;

            var directories = Directory.GetDirectories(_cachePath);
            foreach (var directory in directories) {
                var publisher = Path.GetFileName(directory);
                var subDirectories = Directory.GetDirectories(directory);
                foreach (var subDirectory in subDirectories) {
                    var files = Directory.GetFiles(subDirectory);
                    foreach (var file in files) {
                        if (!file.EndsWith(".unitypackage"))
                            continue;

                        var asset = Path.GetFileNameWithoutExtension(file);
                        _assets[asset] = (publisher, file);
                    }
                }
            }
        }

        void OnGUI() {
            EditorGUILayout.Space(15);
            EditorGUILayout.BeginVertical();

            _cachePath = EditorGUILayout.TextField("Asset Store Cache path", _cachePath);
            if (GUILayout.Button("Refresh")) {
                _assets.Clear();
                _scrollPosition = Vector2.zero;
                EditorPrefs.SetString(_editorPrefsAssetStoreCachePathKey, _cachePath);
                UpdatePackagesList();
            }

            var newShowConfirmation = GUILayout.Toggle(_showConfirmation, "Show confirmation dialog");
            if (newShowConfirmation != _showConfirmation) {
                _showConfirmation = newShowConfirmation;
                EditorPrefs.SetBool(_editorPreShowConfirmationPathKey, _showConfirmation);
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(15);
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            foreach (var (key, value) in _assets.ToList()) {
                var asset = key + " by " + value.Publisher;
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label(asset);

                if (GUILayout.Button("Remove")) {
                    var shouldRemove = !_showConfirmation || EditorUtility.DisplayDialog(
                        "Confirm Asset Removal",
                        $"Are you sure you want to remove\n\n   {asset}\n\n" +
                        "from the Asset Store cache folder on your disk?\n\n" +
                        "You will need to re-download the asset from the Asset Store whenever you need it again.\n\n" +
                        "Assets in your project(s) will remain safe and untouched.",
                        "Remove", "Cancel");

                    if (shouldRemove) {
                        File.Delete(value.Path);
                        _assets.Remove(key);
                    }
                }

                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
        }
    }
}

#endif