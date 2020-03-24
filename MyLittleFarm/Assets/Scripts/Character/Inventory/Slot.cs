using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Inventory inventory;
    public int rowIndex;
    public int columnIndex;
    public Item item;

    void Start()
    {
        inventory = Inventory.Instance;    
    }
    
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(item.itemName);
        Debug.Log("Slot(" + columnIndex + "," + rowIndex + ")" + " is Clicked");
        if (item != null)
        {
            if (inventory.CurrentItem == null)
            {
                //현재 인벤토리에 선택된 아이템이 없는 경우. -> 현재 클릭한 아이템 선택.
                inventory.SetCurrentItem(transform);
                inventory.SetCurrentSlot(columnIndex, rowIndex);
                Debug.Log(inventory.CurrentItem);
            }
            else
            {
                //현재 인벤토리에 선택된 아이템이 있는 경우. -> 두 아이템 위치 바꿔줘.
                inventory.ChangeItemPosition(columnIndex, rowIndex);
                inventory.SetCurrentItem(); //현재 선택 아이템 해제.
                inventory.SetCurrentSlot(); //현재 선택 슬롯 해제.
                Debug.Log(inventory.CurrentItem);
            }
        }
        else
        {

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
*/