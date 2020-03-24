using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour {

    public static TileManager Instance;

    /// <summary>
    /// dictionary<팔레트 이름, list<(타일 이름, 타일 클래스)>>
    /// </summary>
    private Dictionary<string, List<(string name, TileBase tile)>> tileDictionary = new Dictionary<string, List<(string, TileBase)>>();

    public string[] paletteList;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        LoadTiles();
    }

    private void LoadTiles() {
        foreach (var palette in paletteList) {

            tileDictionary.Add(palette, new List<(string, TileBase)>());

            var tiles = Resources.LoadAll("Tiles\\" + palette);

            foreach (var tile in tiles) {
                if ((tile is TileBase) != true)
                    continue;

                tileDictionary[palette].Add((tile.name, tile as TileBase));
            }

        }
    }

    public TileBase GetTile(string palette, int tileId) {
        return tileDictionary[palette][tileId].tile;
    }

    public TileBase GetTile(string palette, string tileName) {
        return tileDictionary[palette].Find(n => n.name.Equals(tileName)).tile;
    }
}