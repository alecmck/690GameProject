﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSimple : MonoBehaviour, InventoryItem
{

    //public string itemName;
    private bool inInventory;
   // public InventoryControl control;

    public void Enter()
    {
        inInventory = true;
        InventoryControl.control.Collect(this);
        this.gameObject.SetActive(false);

    }

    public string GetName()
    {
        return this.gameObject.name;
        //return itemName;
    }

    public bool InInventory()
    {
        return inInventory;
    }

    // Use this for initialization
    void Start()
    {
        inInventory = false;
    }

    public void Remove(Vector3 position, Quaternion rotation)
    {
        inInventory = false;
        this.gameObject.SetActive(true);
        this.gameObject.transform.SetPositionAndRotation(position, rotation);
    }

    private void OnMouseDrag()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Enter();

        }
    }
}
