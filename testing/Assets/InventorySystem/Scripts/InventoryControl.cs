using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{

    public static InventoryControl control;
    //public static GameObject player;*/
    public Transform ContenPanel;
    public GameObject InventoryButton;
    //private Dictionary<string, InventoryItem> Inventory = new Dictionary<string, InventoryItem>();
    private List<InventoryItem> Inventory = new List<InventoryItem>();

    private bool visible = false;
    public GameObject InventoryUI;
    public GameObject InventoryOpenButton;

    public void ShowInventory()
    {
         InventoryUI.SetActive(!visible);
         InventoryOpenButton.SetActive(visible);
        visible = !visible;        
    }

    void Awake()
    {//This makes only one inventory control that is accisible from other scripts. 
        if (control == null)
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
        Inventory.Add(o);
        Debug.Log("Added to Inventory");
        GameObject button = (GameObject)GameObject.Instantiate(InventoryButton);
        Debug.Log("Trying to set up button");
        button.GetComponent<IButton>().SetUp(o, this);
        Debug.Log("trying to add button");
        button.transform.SetParent(ContenPanel);
        Debug.Log("Should have added button");
    }

    public void Use(InventoryItem o)
    {
        o.Remove(Camera.main.ScreenToWorldPoint(Vector3.zero), new Quaternion(0, 0, 0, 0));
        Inventory.Remove(o);
        ShowInventory();
    }

    void Update()
    {

    }
}
