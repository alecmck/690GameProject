using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    /*In Unity:
        1. Create an empty game object (named GameControl for example) and add this script to object
        2. Make sure InventoryItem.cs script is added to the item in the scene that can be added to the inventory. That 
            is the script that allows the user to press E and collect an item, so add that script to the GameObject in the scene
            the player will interact with. This will be your InventoryItem. 
        3. Optional: Create a script that controls the abilities a player will have by having an object in the inventory.
            For example, this would be the script that toggles a flashlight on and off by pressing a key. Add that script
            to an empty GameObject. This will be your InventoryController.
            For flashlight, see instructions in ToggleOnOff.cs
            Items can be made collectable by simply adding InventoryItem.cs script to them, making them an InventoryItem. 
        4. Make sure that the InventoryItem and the InventoryController share the same tag. 
                Add tag in Inspector for each item. May need to create your own tag.
        5. In Inspector of GameControl: enter number of InventoryControllers in size. Add all of your InventoryControllers 
            into the spaces. 
            Note on potential upgrades for later: May pair InventoryController and InventoryItem as children of an 
                empty GameObject and store that in GameControl array. This would allow for InventoryItems to be taken out 
                of inventory/made visible without discarding from inventory so the player could use them in the scene. 
                Also potentially could get rid of hassle that is step 4.
                Potentially could change so that player can only use functionality of item (abilities form InventoryController) 
                    by selecting item in inventory. For example, the player would only be able to use a flashlight 
                    if they select the flashlight out of their inventory. Right now they can always use the flashlight 
                    once they have collected it. 
         6. In scene, great a GUI that will show items in inventory. 
                Create a canvas with a panel. I added a text on the panel that says "Inventory Items"
                Create an empty text on the panel. Add that text in the Inspector of the GameControl GameObject. 
                    This is where the names of the inventory items will appear. Items currently only appear as text.
         7. Items cannot be taken out of inventory yet.*/


    public static GameControl control;
    public GameObject[] InventoryControllers;
    public Text items;

    void Awake()
    {//This keeps the game control around if the scene is change. Currently does not work yet for changing scenes. 
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

    public void Collect(GameObject o) //Called by InventoryItem.cs
    {
        for (int i = 0; i < InventoryControllers.Length; i++)
        {
            if (InventoryControllers[i] != null && InventoryControllers[i].tag.Equals(o.tag)) //Why tags are important
            {
                InventoryControllers[i].SetActive(true);
                break;
            }
        }
        o.SetActive(false);
        items.text += o.name + " \n";
    }

    void Update()
    {

    }
}
