using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    
    public Transform[] rows = new Transform[4]; //인벤토리 UI 각 열의 아이템 슬롯을 포함하고 있는 각 열들

    public readonly static int ColumnInventory = 12;   //인벤토리 열 수
    public readonly static int RowInventory = 4;   //가방 행 전부 해금했을 때의 인벤토리 행 수
    int rowInventory = 2;   //현재 사용 가능한 인벤토리 행 수
    public GameObject slotPrefab;
    public Transform slotHighlight; //선택한 슬롯에 테두리로 표시해줄 게임오브젝트.

    Item[,] items = new Item[ColumnInventory, RowInventory];
    Slot[,] slots = new Slot[ColumnInventory, RowInventory];    //x,y순
    public void SetCurrentSlot() {
        //현재 슬롯 해제.
        slotHighlight.GetComponent<Image>().enabled = false;
        
    }
    public void SetCurrentSlot(int columnIndex, int rowIndex) {
        slotHighlight.position = slots[columnIndex, rowIndex].transform.position;
        slotHighlight.GetComponent<Image>().enabled = true;
    }

    int currentSlotIndex;   //현재 플레이어가 들고 있는 슬롯의 인덱스.
    Transform currentItem; //현재 선택된 아이템 (마우스로 클릭해서 마우스에 따라다니는 아이템)

    public Transform CurrentItem
    {
        get => currentItem;
    }
    public void SetCurrentItem()
    {
        currentItem = null;
    }
    public void SetCurrentItem(Transform slotTransform) {
        currentItem = slotTransform;
    }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //인스펙터 뷰에서 넣어주긴 했는데 혹시 누락하는 경우 생길까봐 찾아서 넣도록 했습니다.
        Transform panelTransform = transform.Find("Panel");
        if (panelTransform != null)
        {
            for (int i = 0; i < panelTransform.childCount; i++)
            {
                rows[i] = panelTransform.GetChild(i);
            }
        }

        //인벤토리 슬롯 생성
        for (int i = 0; i < RowInventory; i++)
        {
            for (int j = 0; j < ColumnInventory; j++)
            {
                GameObject slot = Instantiate(slotPrefab, rows[i]);
                Slot slotScript = slot.GetComponent<Slot>();
                slotScript.rowIndex = i;
                slotScript.columnIndex = j;
                slotScript.item = new Item();   //테스트 하려는 코드.
                slotScript.item.name = "" + (i * ColumnInventory + j);  //테스트용 코드.
                items[j, i] = slotScript.item;  //테스트용
                slots[j, i] = slotScript;
                slot.GetComponentInChildren<Text>().text = "" + (i * ColumnInventory + j);
            }
        }
    }

    void Update()
    {
        if (currentItem != null)
        {
            //currentItem.position = Input.mousePosition;
        }
    }

    public void SetItemPosition(Item item, int targetColumnIndex, int targetRowIndex)
    {
        //start 위치에 있는 item을 end 위치로 지정.
        items[targetColumnIndex, targetRowIndex] = item;
        slots[targetColumnIndex, targetRowIndex].transform.Find("Item").GetComponent<ItemOnInventory>().item = item;
    }

    public void SetItemPosition(int startColumnIndex, int startRowIndex, int endColumnIndex, int endRowIndex) {
        //교환 없이 그냥 덮어 씌움.
        //start 위치에 있는 item을 end 위치로 지정.
        items[endColumnIndex, endRowIndex] = items[startColumnIndex, startRowIndex];

        //슬롯에 있는 item 오브젝트 서로 교체. (이거 그냥 정보 그림 같은 걸 바꿔주는게 좋으려나?!) 일단 편하기는 지금 방식이 편한듯.
        Transform startItem = slots[startColumnIndex, startRowIndex].transform.Find("Item");
        Transform endItem = slots[endColumnIndex, endRowIndex].transform.Find("Item");
        startItem.SetParent(slots[endColumnIndex, endRowIndex].transform);
        endItem.SetParent(slots[startColumnIndex, startRowIndex].transform);
        startItem.localPosition = Vector3.zero;
        endItem.localPosition = Vector3.zero;
        slots[startColumnIndex, startRowIndex].item = items[startColumnIndex, startRowIndex];
        slots[endColumnIndex, endRowIndex].item = items[endColumnIndex, endRowIndex];
    }

    public void ChangeItemPosition(int endColumnIndex, int endRowIndex)
    {
        //currentItem을 end 위치의 아이템과 위치 바꿈.
        Slot currentSlot = currentItem.GetComponent<Slot>();
        ChangeItemPosition(currentSlot.columnIndex, currentSlot.rowIndex, endColumnIndex, endRowIndex);
    }

    public void ChangeItemPosition(int startColumnIndex, int startRowIndex, int endColumnIndex, int endRowIndex) {
        //start 위치에 있는 item을 end 위치의 아이템과 위치 바꿈.
        Item tempItem = items[endColumnIndex, endRowIndex];
        SetItemPosition(startColumnIndex, startRowIndex, endColumnIndex, endRowIndex);
        SetItemPosition(tempItem, startColumnIndex, startRowIndex);
    }
}
*/