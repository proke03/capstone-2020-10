using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class ItemDatabaseEditor : EditorWindow
{
    [MenuItem("Window/UIElements/ItemDatabaseEditor")]
    public static void ShowExample()
    {
        ItemDatabaseEditor wnd = GetWindow<ItemDatabaseEditor>();
        wnd.titleContent = new GUIContent("ItemDatabaseEditor");
    }

    public void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;
        root.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/ItemDatabaseEditor.uss"));
        root.style.flexDirection = FlexDirection.Row;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/ItemDatabaseEditor.uxml");
        visualTree.CloneTree(root);

    }
}