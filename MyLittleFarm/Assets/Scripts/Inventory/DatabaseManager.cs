using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{	
	static public DatabaseManager instance;

	private void Awake() {
		instance = this;
	}

	public List<Item> itemDB = new List<Item>();

	public GameObject fieldItemPrefab;
	public Vector3[] pos;
    // Start is called before the first frame update
    private void Start()
    {
    	for (int i=0; i<5; i++) {
    		GameObject go = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);
    		go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0,2)]);
    	}
    }

}
