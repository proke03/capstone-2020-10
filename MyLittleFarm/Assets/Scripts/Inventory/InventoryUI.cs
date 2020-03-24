using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inven;
    
	public Slot[] slots, minislots;
	public Transform slotHolder, minislotHolder;

    // Start is called before the first frame update
    void Start()
    {
        inven = Inventory.instance;
        slotHolder = inven.slotHolder;
        minislotHolder = inven.minislotHolder;
    	slots = slotHolder.GetComponentsInChildren<Slot>();
    	minislots = minislotHolder.GetComponentsInChildren<Slot>();
        inven.onSlotCountChange += SlotChange;
    }

    private void SlotChange(int val) { //인벤 갯수만큼 슬롯 활성화

        for (int i=0; i<slots.Length; i++ ) {
            minislots[i%12].slotnum = i%12;
            slots[i].slotnum = i;
            if (i < inven.SlotCnt) {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    // Update is called once per frame

    public void AddSlot() {
        inven.SlotCnt = inven.SlotCnt + 12;
    }

}
