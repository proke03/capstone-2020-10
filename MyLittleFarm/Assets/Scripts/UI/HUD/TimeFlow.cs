using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeFlow : UIControl
{
	public Transform Arrow;
	public Text Clocks;
	float Arrowvalue=0;
	public Text cal;
    public Sprite[] season = new Sprite[4];
    public Image currentSeason;  
    string[] day = {"일", "월", "화", "수", "목", "금", "토"};
   	public int Hour = 6;
	public int Minutes = 0;
	public string ampm = "오전";
	public int date = 1;
	public int months = 1;
	public int year = 1;

	IEnumerator Timer() { 
		yield return new WaitForSeconds(1f); 
		Minutes++;
		
		if (Minutes == 60){
			Hour++;
			Minutes = 0;
			if (Hour>25) {
        		Hour = 6;
        		date++;
        		if (date > 28) {
        			months ++;
        			date = 1;
        			if (months > 4){
        				year++;
        				months = 1;
        			}
        		}
        	}
		}

		if (Hour >= 12 && Hour < 24) ampm = "오후";
		else ampm = "오전";

		StartCoroutine("Timer");

	}

	void Awake(){
		if (Arrow == null) return;
	}
    void Start()
    {
    	StartCoroutine("Timer");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {	
    	    Clocks.text = string.Format("{2} {0:00} : {1:00}", Hour>12 ? Hour%12 : Hour, (Minutes/10)*10, ampm);
        	Arrowvalue = ((float)(Hour-6)/20)*180f+((float)Minutes/60)*9f;
        	Arrow.transform.localRotation = Quaternion.Euler(0f,0f,90-Arrowvalue);
        	cal.text = string.Format("{0}일, {1}요일", date, day[(date-1)%7]);
        	currentSeason.GetComponent<Image>().sprite = season[months-1];
    }
}
