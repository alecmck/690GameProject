using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
               
    public static GameControl control;
    public static GameObject player;
    public Transform ContenPanel;
    public GameObject InventoryButton;
    //public Text items;
    // private InventoryItem[] inventory = new InventoryItem[10];
    private Dictionary<string, InventoryItem> Inventory = new Dictionary<string, InventoryItem>();
    //public GameObject canvas;
    //public GameObject itemEntry;
    
	void Awake () {//This keeps the game control around if the scene is change. Currently does not work yet for changing scenes. 
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
	}


    public void Collect(InventoryItem o) //Called by InventoryItem.cs
    {
        Debug.Log("Collect");
        Inventory.Add(o.GetName(), o);
        Debug.Log("Added to Inventory");
        GameObject button = (GameObject)GameObject.Instantiate(InventoryButton);
        Debug.Log("Trying to set up button");
        button.GetComponent<IButton>().SetUp(o, this);
        Debug.Log("trying to add button");
        button.transform.SetParent(ContenPanel);
        Debug.Log("Should have added button");
     }

    public void Use(string o)
    {
        InventoryItem i = Inventory[o];
        i.Remove(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Quaternion(0,0,0,0));
        Inventory.Remove(o);
    }

	void Update () {
		
	}
}
 