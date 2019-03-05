using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemImpl : MonoBehaviour, InventoryItem {

    public GameControl control;
    private ItemControl iControl; 
    private ItemView iView;
    public string itemName;
   
   public string GetName()
    {
        return itemName;
    }

   void Start()
    {
        iControl = GetComponentInChildren<ItemControl>();
        iView = GetComponentInChildren<ItemView>();
    }

      public bool InInventory()
    {
        throw new System.NotImplementedException();
    }

    public void Enter()
    {
        Debug.Log("Enter InventoryItem");
        if (iView != null && iControl != null)
        {
            Debug.Log("Not Null");
            iControl.ActivateControl();
            iView.Hide();
        }
        Debug.Log("Calling Collect");
        control.Collect(this);
    }

    public void Remove(Vector3 position, Quaternion rotation)
    {
        if (iView != null && iControl != null)
        {
            Debug.Log("NOT NULL YAY");
            iControl.DeactivateControl();
            iView.Remove(position, rotation);
        }
        //control.Collect(this);
    }
}
