//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(Map))]
//public class MapEditor : Editor {
//    public Sprite sprite;

//    private void OnEnable() {
//        sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Resources/Sprites/box.png");
//    }

//    private void OnSceneGUI() {
//        if (SceneView.lastActiveSceneView != null) {
//            Handles.BeginGUI();

//            var pos = Event.current.mousePosition;

//            float size = SceneView.lastActiveSceneView.size;
//            float scale = (1 / size) * 31.0f;//size * (16 * 4);

//            Debug.Log(SceneView.lastActiveSceneView.camera.pixelRect);


//            GUI.Button(new Rect(32, 32, 64, 24), "button");

//            var pivot = sprite.pivot;
//            GUI.DrawTexture(new Rect(pos.x, pos.y, sprite.texture.width * scale, sprite.texture.height * scale), sprite.texture);

//            Handles.EndGUI();
//            SceneView.lastActiveSceneView.Repaint();
//        }
//    }
//}