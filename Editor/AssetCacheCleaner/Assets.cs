using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using static System.String;
using static System.StringComparison;

namespace AssetCacheCleaner {
    internal class Assets {
        readonly List<AssetInfo> _assets = new();

        public List<AssetInfo> AssetsInfo => _assets;

        public void Refresh(string assetStoreCachePath) {
            _assets.Clear();

            if (!Directory.Exists(assetStoreCachePath))
                return;

            var publisherDirectoryPaths = Directory.GetDirectories(assetStoreCachePath);
            foreach (var publisherDirectoryPath in publisherDirectoryPaths) {
                var publisher = Path.GetFileName(publisherDirectoryPath);
                var assetDirectoryPaths = Directory.GetDirectories(publisherDirectoryPath);
                foreach (var assetDirectoryPath in assetDirectoryPaths) {
                    var assetFilePaths = Directory.GetFiles(assetDirectoryPath);
                    foreach (var assetFilePath in assetFilePaths) {
                        if (!assetFilePath.EndsWith(".unitypackage"))
                            continue;

                        var asset = Path.GetFileNameWithoutExtension(assetFilePath);

                        _assets.Add(new AssetInfo {
                            Asset = asset,
                            Publisher = publisher,
                            AssetPath = assetFilePath
                        });
                    }
                }
            }
        }

        public void RemoveAll() {
            foreach (var asset in _assets)
                File.Delete(asset.AssetPath);

            _assets.Clear();
        }

        public string GetAsset(int index) {
            if (index < 0 || index >= _assets.Count)
                return null;

            return _assets[index].Asset;
        }

        public string GetPublisher(int index) {
            if (index < 0 || index >= _assets.Count)
                return null;

            return _assets[index].Publisher;
        }

        public void Remove(int index) {
            if (index < 0 || index >= _assets.Count)
                return;

            var assetInfo = _assets[index];
            File.Delete(assetInfo.AssetPath);
            _assets.RemoveAt(index);
        }

        public void SortByAsset(SortDirection direction) {
            if (direction == SortDirection.Ascending)
                SortAssetsAscendingThenPublishersAscending();
            else
                SortAssetsDescendingThenPublishersDescending();
        }

        public void SortByAssetThenPublisher(SortDirection assetDirection, SortDirection publisherDirection) {
            switch (assetDirection) {
                case SortDirection.Ascending when publisherDirection is SortDirection.Ascending:
                    SortAssetsAscendingThenPublishersAscending();
                    break;
                case SortDirection.Ascending when publisherDirection is SortDirection.Descending:
                    SortAssetsAscendingThenPublishersDescending();
                    break;
                case SortDirection.Descending when publisherDirection is SortDirection.Ascending:
                    SortAssetsDescendingThenPublishersAscending();
                    break;
                case SortDirection.Descending when publisherDirection is SortDirection.Descending:
                    SortAssetsDescendingThenPublishersDescending();
                    break;
            }
        }

        public void SortAssetsAscendingThenPublishersAscending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(a.Asset, b.Asset, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(a.Publisher, b.Publisher, OrdinalIgnoreCase);
            });

        public void SortAssetsAscendingThenPublishersDescending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(a.Asset, b.Asset, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(b.Publisher, a.Publisher, OrdinalIgnoreCase);
            });

        public void SortAssetsDescendingThenPublishersAscending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(b.Asset, a.Asset, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(a.Publisher, b.Publisher, OrdinalIgnoreCase);
            });

        public void SortAssetsDescendingThenPublishersDescending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(b.Asset, a.Asset, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(b.Publisher, a.Publisher, OrdinalIgnoreCase);
            });

        public void SortByPublisher(SortDirection direction) {
            if (direction == SortDirection.Ascending)
                SortPublishersAscendingThenAssetsAscending();
            else
                SortPublishersDescendingThenAssetsDescending();
        }

        public void SortByPublisherThenByAsset(SortDirection publisherDirection, SortDirection assetDirection) {
            switch (publisherDirection) {
                case SortDirection.Ascending when assetDirection is SortDirection.Ascending:
                    SortPublishersAscendingThenAssetsAscending();
                    break;
                case SortDirection.Ascending when assetDirection is SortDirection.Descending:
                    SortPublishersAscendingThenAssetDescending();
                    break;
                case SortDirection.Descending when assetDirection is SortDirection.Ascending:
                    SortPublishersDescendingThenAssetsAscending();
                    break;
                case SortDirection.Descending when assetDirection is SortDirection.Descending:
                    SortPublishersDescendingThenAssetsDescending();
                    break;
            }
        }

        public void SortPublishersAscendingThenAssetsAscending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(a.Publisher, b.Publisher, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(a.Asset, b.Asset, OrdinalIgnoreCase);
            });

        public void SortPublishersAscendingThenAssetDescending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(a.Publisher, b.Publisher, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(b.Asset, a.Asset, OrdinalIgnoreCase);
            });

        public void SortPublishersDescendingThenAssetsAscending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(b.Publisher, a.Publisher, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(a.Asset, b.Asset, OrdinalIgnoreCase);
            });

        public void SortPublishersDescendingThenAssetsDescending() =>
            _assets.Sort(static (a, b) => {
                var result = Compare(b.Publisher, a.Publisher, OrdinalIgnoreCase);
                return result != 0 ? result : Compare(b.Asset, a.Asset, OrdinalIgnoreCase);
            });
    }
}