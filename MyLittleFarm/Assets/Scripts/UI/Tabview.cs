using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tabview : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tab, inventoryPanel, hotkeyPanel, SettingPanel, StatPanel, 
    MapPanel, CraftingPanel, TrophyPanel, BookPanel, OptionPanel, TabBar;
    public bool activeTab = false;
    Toggle[] toggle;
    public Transform toggleHolder;

    void Start()
    {
    	toggle = toggleHolder.GetComponentsInChildren<Toggle>();
    	for (int i=0; i<toggle.Length; i++){
    		toggle[i].isOn = false;
    	}
    	activeTab = false;
    	TabBar.SetActive(false);
        inventoryPanel.SetActive(false);
        hotkeyPanel.SetActive(true);
        SettingPanel.SetActive(false);
        StatPanel.SetActive(false);
        MapPanel.SetActive(false);
        TrophyPanel.SetActive(false);
        BookPanel.SetActive(false);
        OptionPanel.SetActive(false);
        CraftingPanel.SetActive(false);
    }

    void CloseTab() {
    	activeTab = false;
   	for (int i=0; i<toggle.Length; i++){
    		toggle[i].isOn = false;
    	}
    	TabBar.SetActive(false);
        inventoryPanel.SetActive(false);
        hotkeyPanel.SetActive(true);
        SettingPanel.SetActive(false);
        StatPanel.SetActive(false);
        MapPanel.SetActive(false);
        TrophyPanel.SetActive(false);
        BookPanel.SetActive(false);
        OptionPanel.SetActive(false);
        CraftingPanel.SetActive(false);
     }
    // Update is called once per frame
    void Update()
    {
    	if (activeTab == true && Input.GetKeyDown(KeyCode.Escape))
    		CloseTab();
    	else {
			if (Input.GetKeyDown(KeyCode.Escape)) {        	
   				activeTab = true;
   				TabBar.SetActive(true);
   				toggle[7].isOn = true;
    		    SettingPanel.SetActive(true);
        	}  
        	else if (Input.GetKeyDown(KeyCode.I)) {
   				TabBar.SetActive(true);
        		toggle[0].isOn = true;
        		activeTab = true;
        		inventoryPanel.SetActive(true);
        	} 		
        	else if (Input.GetKeyDown(KeyCode.K)) {
        		activeTab = true;
   				TabBar.SetActive(true);
        		toggle[1].isOn = true;
    	    	StatPanel.SetActive(true);
        	}
        	else if (Input.GetKeyDown(KeyCode.M)) {
        		activeTab = true;
    	    	MapPanel.SetActive(true);
        	}
        	else if (Input.GetKeyDown(KeyCode.C)) {
        		activeTab = true;
   				TabBar.SetActive(true);
        		toggle[3].isOn = true;
    	    	CraftingPanel.SetActive(true);
        	}
        }

        if (activeTab == true ) {
			Time.timeScale = 0;
			hotkeyPanel.SetActive(false);
        }
        else {
        	Time.timeScale = 1;
        	hotkeyPanel.SetActive(true);
		}
    }
}
