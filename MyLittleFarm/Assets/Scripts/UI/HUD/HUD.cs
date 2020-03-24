using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	GameObject HPbar;
	Slider HP_bar;
    // Start is called before the first frame update
    void Start()
    {
        HPbar = GameObject.Find("HPbar");
        HP_bar = GameObject.Find("HP_bar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP_bar.value == HP_bar.maxValue) HPbar.SetActive(false);
    	else HPbar.SetActive(true);
    }
}
