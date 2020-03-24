using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IPointerDownHandler
{

   Slot slots;
   Inventory inven;
   bool pick;
   private Vector3 OriginPos, pos;
   public int slotnum;
   public Item item;
   public Image ItemImage;
   public int itemCount;
   public PointerEventData.InputButton btnR = PointerEventData.InputButton.Right;
   public PointerEventData.InputButton btnL = PointerEventData.InputButton.Left;

   [SerializeField]
   private TextMeshProUGUI text_Count;
   [SerializeField]
   private GameObject go_CountImage;

   void Start() {
      inven = Inventory.instance;
      OriginPos = transform.position;
      slots = this;
      pick = false;
   }

   void Update() {
      pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
      if (pick == true){
         DragSlot.instance.transform.position = pos;
      }
   }

   //아이템 획득
   public void AddItem(Item _item, int _count = 1) {
      item = _item;
      itemCount = _count;
      ItemImage.sprite = item.itemImage;
      ItemImage.gameObject.SetActive(true);
      if(item.itemType != Item.ItemType.Equip) {
         go_CountImage.SetActive(true);
         text_Count.text = itemCount.ToString();
      }
      else {
         text_Count.text = "0";
         go_CountImage.SetActive(false);
      }
      SetColor(1);
   }

   //아이템 갯수 조정
   public void SetSlotCount(int _count) {
      itemCount += _count;
      if (itemCount > 1){
         text_Count.text = itemCount.ToString();
      }
      if (itemCount <= 0) RemoveSlot();
   }

   //슬롯 초기화
   public void RemoveSlot() {
   	item = null;
      itemCount = 0;
      ItemImage.sprite = null;
      SetColor(0);

      text_Count.text = "0";
      go_CountImage.SetActive(false);
   }

   public void OnPointerDown(PointerEventData eventData) {
      if (eventData.button == btnR){ // 우클릭시 아이템 사용
         pos = transform.position;
         if (item != null) {
            if (item.itemType == Item.ItemType.Use) {
               if (itemCount > 1) {
                  itemCount-=1;
                  text_Count.text = itemCount.ToString();
                  if (pos.y > 60) inven.RedrawSlotUI();
                  else inven.RedrawSlotUI2();

               }
               else {
                  Debug.Log("0이하");
                  RemoveSlot();
                  if (pos.y > 60) inven.RedrawSlotUI();
                  else inven.RedrawSlotUI2();
               }
               //장비창으로 이동+스탯 적용 추가 필요
            }
         }
      } 
      else if (eventData.button == btnL) { //좌클릭시 아이템 선택
         if (pick == false && item!= null){
            if (pos.y > 60){
               DragSlot.instance.dragSlot = this;
               DragSlot.instance.DragSetImage(ItemImage);
               pick = true;
            }
         }
         else {
            if (DragSlot.instance.dragSlot != null) {
               if (slots.GetComponent<Button>().interactable == true){
                  ChangeSlot();
                  inven.RedrawSlotUI();
               }
            }
            pick = false;
            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
         }
      }
   }

   //슬롯 바꾸기
   private void ChangeSlot() {
      Item _tempItem = item;
      int _tempItemCount = itemCount;

      AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

      if (_tempItem != null) {
         DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
      }
      else {
         DragSlot.instance.dragSlot.RemoveSlot();
      }
   } 

   //이미지 투명도 조절
   public void SetColor(float _alpha) {
      Color color = ItemImage.color;
      color.a = _alpha;
      ItemImage.color = color;
   }
}
