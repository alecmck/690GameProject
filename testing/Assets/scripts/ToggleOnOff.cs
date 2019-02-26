using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Place on some GameObject (empty GameObect). 
 * Add object you want to toggle as "myObject." For flashlight, this would be a spotlight. 
   Add key that will control on/off as "key"*/

/*Flashlight Instructions:
    1. Add spotlight to FirstPersonCharacter. Adjust positiong and rotation of spotlight. 
    2. Change color, range, intensity, cookie of spotlight to change effect.*/

public class ToggleOnOff : MonoBehaviour
{

    public GameObject myObject;
    public char key;
    private bool active = true;

    private void Update()
    {
        if (Input.GetKeyDown(key.ToString()))
        {
            myObject.SetActive(active);
            active = !active;
        }
    }
}
