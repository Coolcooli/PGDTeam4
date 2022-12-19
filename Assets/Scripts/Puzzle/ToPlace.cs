using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToPlace : Interactable
{
    public UnityEvent Remove;

    [SerializeField]
    private List<Pickupable> placeables;
    public bool placed = false;

    public override void OnInteract()
    {
        if (!placed)
            return;

        onInteract?.Invoke();
    }

    public bool Interaction(Pickupable placeable)
    {
        if(placed)
        {
            placed = false;
            print("remove");
            Remove.Invoke();
            return false;
        }
        //checking if the holding item matches the required item
        else if (placeables.Contains(placeable))
        {
            placed = true;
            print("place");
            OnInteract();
            return true;
        }

        return false;
    }
}
