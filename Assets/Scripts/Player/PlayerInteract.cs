using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    TMP_Text interactionText;

    [SerializeField]
    public static int InteractRange = 3;//the range how far away the player can interact with objects
    private Transform cam;//the camera of the player
    private PlayerInventory inventory;

    private RaycastHit hit;

    private void Awake()
    {
        cam = Camera.main.transform;
        inventory = GetComponent<PlayerInventory>();
    }

    private void FixedUpdate()
    {
        string currentInteractText = "";
        if (Physics.Raycast(cam.position, cam.forward, out hit, InteractRange))
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                currentInteractText = interactable.InteractText;
            }
        }
        interactionText.text = currentInteractText;
    }

    /// <summary>
    /// function that calls the interact event on the object the player is looking at
    /// </summary>
    public void Interact(CallbackContext context)
    {
        if (context.performed)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, InteractRange))
            {
                hit.collider.GetComponent<IInteract>()?.OnInteract();

                Pickupable pickup = hit.collider.GetComponent<Pickupable>();
                if (pickup != null)
                {
                    inventory.Add(pickup);
                }

                LockedDoor door = hit.collider.GetComponent<LockedDoor>();
                if (door != null)
                {
                    if (door.Interaction(inventory.Holding))
                    {
                        inventory.UseItem();
                    }
                }

                ToPlace placeable = hit.collider.GetComponent<ToPlace>();

                if (placeable == null)
                    return;

                if (inventory.Holding is not Placeable)
                    return;

                if (placeable.Interaction(inventory.Holding as Placeable))
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
