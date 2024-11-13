using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractionType { Door, Button, Pickup}

    public InteractionType type;
    public bool activated;

    public PickUp pickUpItem;
    public void Activate()
    {
        activated = true;
        
        if (type == InteractionType.Pickup)
        {
            pickUpItem.PickUpItem();
        }
        else
        {
            Debug.Log($"{type} was activated");
        }
    }
}
