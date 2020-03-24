using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather : MonoBehaviour
{
	public Sprite[] weathers = new Sprite[3]; //0:rainy, 1:sunny, 2:snowy
    public Image todayWeather;  
    int rand;
    int hour_tmp, flag=0;
    // Start is called before the first frame update
    void Start()
    {
    }
    void random() {
        int month_tmp = GameObject.Find("UImanager").GetComponent<TimeFlow>().months;
        int tmp = Random.Range(0,100);
        switch(month_tmp){
            case 1:
                if (tmp <= 40) rand = 0;
                else rand = 1;
                break;
            case 2: 
                if (tmp <= 30) rand = 0;
                else rand = 1;
                break;
            case 3:
                if (tmp <= 65) rand = 0;
                else rand = 1;
                break;
            case 4:
                if (tmp <= 50) rand = 2;
                else rand = 1;
                break;
            default: break;
        }
    }
    // Update is called once per frame
    void Update()
    {	
        hour_tmp = GameObject.Find("UImanager").GetComponent<TimeFlow>().Hour;
        if (hour_tmp == 6 && flag == 0) {
            random();
            todayWeather.GetComponent<Image>().sprite = weathers[rand];
            flag = 1;
        }
        else if (hour_tmp > 6) flag = 0;
    }
}
