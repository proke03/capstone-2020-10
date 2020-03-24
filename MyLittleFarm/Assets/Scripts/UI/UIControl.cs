using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    [SerializeField] public GameObject Tab;    
	public void doExitGame() {
		#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
 	}
 	public void change2gameScence(){
 		SceneManager.LoadScene("Test_UI");
 	}
 	public void change2Menu(){
 		SceneManager.LoadScene("JH");
 	}
 
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

}
