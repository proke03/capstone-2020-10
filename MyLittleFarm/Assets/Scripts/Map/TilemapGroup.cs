using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// tilemap system
/// </summary>
namespace ts {

    public class TilemapGroup : MonoBehaviour {
        public static TilemapGroup Instance;

        //public int layerCount = 8;

        public List<TilemapLayer> layers = new List<TilemapLayer>();

        private void Awake() {
            if (Instance == null) {
                Instance = this;

                //#if !UNITY_EDITOR
                Initialize();
                //#endif
            } else {
                Destroy(gameObject);
            }
        }

        public void Initialize() {
            layers.Clear();

            //Debug.Assert(layerCount == transform.childCount, "layerCount와 레이어 실제 개수가 맞지 않음");

            //int l0 = LayerMask.NameToLayer("L0");

            //for (int i = 0; i < layerCount; i++) {
            //    var layer = transform.GetChild(i);

            //    layers.Add((layer.GetChild(0).GetComponent<Tilemap>(), layer.GetChild(1).GetComponent<Tilemap>()));
            //}

            foreach (Transform layer in transform) {
                layers.Add(new TilemapLayer() {
                    terrain_ = layer.GetChild(0).GetComponent<Tilemap>(),
                    event_ = layer.GetChild(1).GetComponent<Tilemap>()
                });
            }

            //var tempList = new List<(Tilemap back, Tilemap fore)>();
            //foreach (Transform layer in transform) {
            //    /// 앞 글자가 Layer인 오브젝트만 추가
            //    if (layer.gameObject.name.Substring(0, 5).Equals("Layer")) {
            //        tempList.Add((layer.GetChild(0).GetComponent<Tilemap>(), layer.GetChild(1).GetComponent<Tilemap>()));
            //    } else { // 이벤트 타일맵 로드
            //        for (int i = 0; i < tempList.Count; i++) {
            //            layers.Add((tempList[i].back, layer.GetChild(i).GetComponent<Tilemap>()));
            //        }
            //    }
            //}
            //tempList.Clear();
        }

        public bool enableDebugLayerNumber = true;

#if UNITY_EDITOR

        public void OnDrawGizmos() {
            if (enableDebugLayerNumber) {

                Dictionary<Vector3Int, string> dict = new Dictionary<Vector3Int, string>();
                for (int i = 0; i < layers.Count; i++) {
                    var layer = layers[i];

                    foreach (var pos in layer.terrain_.cellBounds.allPositionsWithin) {
                        if (layer.terrain_.GetTile(pos) != null) {
                            if (!dict.ContainsKey(pos))
                                dict.Add(pos, i + " ");
                            else {
                                dict[pos] += i + " ";
                            }
                        }
                    }

                    foreach (var pos in layer.event_.cellBounds.allPositionsWithin) {
                        if (layer.event_.GetTile(pos) != null) {
                            if (!dict.ContainsKey(pos))
                                dict.Add(pos, "E" + i + " ");
                            else {
                                dict[pos] += "E" + i + " ";
                            }
                        }
                    }
                }

                foreach (var d in dict) {

                    Handles.Label(d.Key + Vector3.up, d.Value);

                }

            }
        }

#endif

    }

}