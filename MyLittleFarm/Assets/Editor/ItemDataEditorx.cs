using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class ItemDataEditorx : EditorWindow {
    static ItemDataEditorx window;

    List<ToolData> toolList = new List<ToolData>();
    ListView toolListView;

    VisualElement listContainer;
    VisualElement infoContainer;

    [MenuItem("Window/ItemDatabase")]
    static void ShowWindow() {
        window = GetWindow<ItemDataEditorx>();
        window.minSize = new Vector2(720, 480);
    }

    private void OnEnable() {
        var root = rootVisualElement;
        root.style.flexDirection = FlexDirection.Row;

        listContainer = new VisualElement();
        listContainer.style.width = 240;
        listContainer.style.borderRightWidth = 1.0f;
        listContainer.style.borderColor = Color.black;
        root.Add(listContainer);

        infoContainer = new VisualElement();
        root.Add(infoContainer);

        var buttonContainer = new VisualElement();
        buttonContainer.style.flexDirection = FlexDirection.Row;
        listContainer.Add(buttonContainer);

        var addItemButton = new Button(() => {
            var tool = ScriptableObject.CreateInstance<ToolData>();

            toolList.Add(tool);
            toolListView.Refresh();
        });
        addItemButton.style.width = 24;
        addItemButton.style.height = 24;
        addItemButton.text = "+";
        buttonContainer.Add(addItemButton);

        var removeItemButton = new Button();
        removeItemButton.style.width = 24;
        removeItemButton.style.height = 24;
        removeItemButton.text = "-";
        buttonContainer.Add(removeItemButton);


        toolListView = new ListView(toolList, 36, () => {
            var box = new VisualElement();

            //box.style.flexDirection = FlexDirection.Row;
            //box.style.flexGrow = 1f;
            //box.style.flexShrink = 0f;
            //box.style.flexBasis = 0f;
            box.Add(new Label());
            box.Add(new Label());

            return box;
        }, (VisualElement e, int index) => {
            (e.ElementAt(0) as Label).text = toolList[index].name;
            (e.ElementAt(1) as Label).text = "설명";//toolList[index].description;
        });
        toolListView.style.flexGrow = 1f;
        toolListView.style.flexShrink = 0f;
        toolListView.style.flexBasis = 0f;
        toolListView.onItemChosen += (object obj) => {
        };

        toolListView.onSelectionChanged += (List<object> obj) => {
            var tool = obj[0] as ToolData;
            ShowToolInfo(tool);

            toolListView.Refresh();
        };

        listContainer.Add(toolListView);



        //var serializedObject = new SerializedObject(toolList);
    }

    void ShowToolInfo(ToolData tool) {
        infoContainer.Clear();

        var serializedObject = new SerializedObject(tool);

        //var property = ;
        var nameElement = new TextField("이름", 100, false, false, '*');
        nameElement.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/ItemDatabaseEditor.uss"));
        nameElement.BindProperty(serializedObject.FindProperty("name"));

        infoContainer.Add(nameElement);
    }
}