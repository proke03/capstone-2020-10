using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EP : MonoBehaviour
{
   public Text EP_text;
    float nowEP, MAXEP;

    public void EP_PointerEnter() {
        EP_text.gameObject.SetActive(true);
    }
    public void EP_PointerExit() {
        EP_text.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    	
    }

    // Update is called once per frame
    void Update()
    {
       nowEP = GameObject.Find("EP_bar").GetComponent<Slider>().value;
       MAXEP = GameObject.Find("EP_bar").GetComponent<Slider>().maxValue;

       if (nowEP <= 0) transform.Find("Fill Area").gameObject.SetActive(false);
       else transform.Find("Fill Area").gameObject.SetActive(true);
       
       EP_text.text = string.Format("{0}/{1}", nowEP, MAXEP);
    }
}
