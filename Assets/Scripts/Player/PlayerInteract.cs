using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    public static int InteractRange = 3;//the range how far away the player can interact with objects
    [SerializeField]
    private Transform cam;//the camera of the player
    [SerializeField]
    private PlayerInventory inventory;

    /// <summary>
    /// function that calls the interact event on the object the player is looking at
    /// </summary>
    public void Interact()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, InteractRange)){
            hit.collider.GetComponent<IInteract>()?.OnInteract();

            Pickupable pickup = hit.collider.GetComponent<Pickupable>();
            if (pickup != null)
            {
                inventory.Add(pickup);
            }

            LockedDoor door = hit.collider.GetComponent<LockedDoor>();
            if(door != null)
            {
                if (door.Interaction(inventory.Holding))
                {
                    inventory.UseItem();
                }
            }

            ToPlace placeable = hit.collider.GetComponent<ToPlace>();
            print(placeable);
            if (placeable != null)
            {
                if(placeable.Interaction(inventory.Holding))
                {
                    Pickupable item = inventory.Holding;
                    inventory.Drop();
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.transform.position = placeable.transform.position;
                    item.transform.rotation = placeable.transform.rotation;

                }
            }
        }
    }
}
