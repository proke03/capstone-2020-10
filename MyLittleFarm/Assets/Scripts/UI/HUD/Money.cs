using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
	public Text Goldtext;
    public Text UIgold;
	int gold = 0 ;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Goldtext.text = string.Format("{0} 원", gold);
        UIgold.text = string.Format("{0} 원", gold);
    }
}
