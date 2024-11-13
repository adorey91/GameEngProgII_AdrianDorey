using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpItem")]
public class PickUp : ScriptableObject
{
    public string itemName;


    public void PickUpItem()
    {
        Debug.Log("Picking up " + itemName);
    }
}
