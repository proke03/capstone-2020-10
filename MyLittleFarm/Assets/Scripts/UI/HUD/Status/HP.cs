using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Text HP_text;
    float nowHP,MAXHP;

    public void HP_PointerEnter() {
        HP_text.gameObject.SetActive(true);
   }
    public void HP_PointerExit() {
        HP_text.gameObject.SetActive(false);
    }
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        nowHP = GameObject.Find("HP_bar").GetComponent<Slider>().value;
        MAXHP = GameObject.Find("HP_bar").GetComponent<Slider>().maxValue;

        if (nowHP <= 0) transform.Find("Fill Area").gameObject.SetActive(false);
        else transform.Find("Fill Area").gameObject.SetActive(true);
        
        HP_text.text = string.Format("{0}/{1}", nowHP, MAXHP);
    }
}
