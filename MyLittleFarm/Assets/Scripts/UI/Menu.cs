using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    static public Menu instance;

    private void Awake() {
        if (instance != null) {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    
 	[SerializeField]
	GameObject trophy;	
	[SerializeField]
	GameObject loading;

    public void openTrophy(){
    	trophy.SetActive(true);
    }
    public void openLoading(){
    	loading.SetActive(true);
    }
    public void closePopUp(){
    	trophy.SetActive(false);
		loading.SetActive(false);
    }
    void Start()
    {
        closePopUp();
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Escape))
    	{
    		closePopUp();
    	}
    }

}
