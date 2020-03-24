using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

	#region Singleton
	public static Inventory instance;
	private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
			return;
		}
		instance = this;
	}
	#endregion
    // Start is called before the first frame update
	public Slot[] slots, minislots;
	public Transform slotHolder, minislotHolder;
	int hotkeyNum = 0;

	public delegate void OnSlotCountChange(int val);
	public OnSlotCountChange onSlotCountChange;

	Tabview tab;

    private int slotCnt;
    public int SlotCnt{
    	get => slotCnt;
    	set {
    		slotCnt = value;
    		if (onSlotCountChange != null)
    			onSlotCountChange.Invoke(slotCnt);
    	}
    }
    void Start()
    {
        SlotCnt = 12;
        slots = slotHolder.GetComponentsInChildren<Slot>();
        tab = GameObject.Find("UImanager").GetComponent<Tabview>();
        minislots = minislotHolder.GetComponentsInChildren<Slot>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) { //핫키 바꾸기
        	for (int i=12*hotkeyNum; i<12*(hotkeyNum+1) ; i++ ) {
        		minislots[i%12].RemoveSlot();
        	}
        	if (SlotCnt == 24) hotkeyNum = (hotkeyNum+1)%2;
        	if (SlotCnt == 36) hotkeyNum = (hotkeyNum+1)%3;
        	Debug.Log(hotkeyNum);
        	RedrawSlotUI();
        }
    }

    public bool AcquireItem(Item _item, int _count = 1) {
    	if (Item.ItemType.Use == _item.itemType) {
    		for (int i=0; i<SlotCnt; i++) {
    			if (slots[i].item != null ) {
    			    if (slots[i].item.itemName == _item.itemName) {
    					slots[i].SetSlotCount(_count);
                        RedrawSlotUI();
    					return true;
    				}	
    			}
    		}
    	}
    	for (int i=0; i<SlotCnt; i++) {
    		if (slots[i].item == null) {
    			slots[i].AddItem(_item, _count);
                RedrawSlotUI();
    			return true;
    		}
    	}
    	return false;
    }

    public void RedrawSlotUI() { //인벤 및 핫키 아이템 나타내기
        Debug.Log("Redraw 실행");
        for (int i=0; i<minislots.Length; i++) {
        	minislots[i].RemoveSlot();
        }
        for (int i=0; i<slots.Length; i++) {
            if (i>=12*hotkeyNum && i<12*(hotkeyNum+1)) {
            	if (slots[i].item != null){
					minislots[i%12].AddItem(slots[i].item, slots[i].itemCount);
                    Debug.Log("Redraw 아이템 추가"+ slots[i].itemCount+" "+ minislots[i%12].itemCount);

                }
            }
        }
    }
    public void RedrawSlotUI2() { //인벤 및 핫키 아이템 나타내기
        Debug.Log("Redraw2 실행");
        for (int i=0; i<slots.Length; i++) {
            slots[12*hotkeyNum+i].RemoveSlot();
        }
        for (int i=0; i<minislots.Length; i++) {
            if (minislots[i].item != null){
                slots[12*hotkeyNum+i].AddItem(minislots[i].item, minislots[i].itemCount);
                Debug.Log("Redraw 아이템 추가"+ slots[i].itemCount+" "+ minislots[i%12].itemCount);
            }
        }
    }
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.CompareTag("FieldItem")) {
					Debug.Log("충돌");

			FieldItems fieldItems = collision.GetComponent<FieldItems>();
			if (AcquireItem(fieldItems.GetItem())) {
									Debug.Log("획득");

				fieldItems.DestroyItem();
				RedrawSlotUI();

			}
		}
	} 
}
