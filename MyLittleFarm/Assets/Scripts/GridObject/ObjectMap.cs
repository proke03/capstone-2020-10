//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CreativeSpore.SuperTilemapEditor;

//public class ObjectMap : MonoBehaviour {
//    private Dictionary<(int x, int y), GridObject> objectList = new Dictionary<(int x, int y), GridObject>();

//    private void Awake() {
//        foreach (Transform child in transform) {
//            if (!child.gameObject.activeInHierarchy) continue;

//            var gp = TilemapUtils.GetGridPosition(GameManager.Instance.backgroundTilemap, child.position);

//            var gridObject = child.GetComponent<GridObject>();
//            gridObject.Initialize(gp.x, gp.y);

//            objectList.Add((gp.x, gp.y), gridObject);
//        }

//        //foreach (var i in objectList) {
//        //    var (x, y) = i.Key;
//        //}
//    }

//    public bool ExistObject(int x, int y) {
//        return objectList.ContainsKey((x, y));
//    }

//    public GridObject GetObject(int x, int y) {
//        return objectList[(x, y)];
//    }

//    public bool RemoveObject(int x, int y) {
//        return objectList.Remove((x, y));
//    }
//}