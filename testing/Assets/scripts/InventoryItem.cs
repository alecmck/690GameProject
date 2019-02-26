using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{

    /*In Unity: 
     *  Add to item in scene that can be added to inventory. 
     *  In inspector: add GameControl object with GameControl.cs script as parameter*/
    public GameControl control;

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            control.Collect(this.gameObject);
        }

    }
}