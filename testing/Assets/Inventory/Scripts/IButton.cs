using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IButton : MonoBehaviour
{
    public Text t;
    private GameControl control;
    private string Name;
    public void SetUp(InventoryItem i, GameControl c)
    {
        t.text = i.GetName();
        Name = i.GetName();
        control = c;
    }

    private void OnMouseDrag()
    {
        Debug.Log("MouseDrag");
        control.Use(Name);
        this.gameObject.SetActive(false);
    }

    public void Use()
    {
        control.Use(Name);
        this.gameObject.SetActive(false);
    }
}
