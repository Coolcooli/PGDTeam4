using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDoor : MonoBehaviour
{
    [SerializeField]
    protected List<Animation> wings;

    [SerializeField]
    private bool isLocked;

    [SerializeField]
    private AudioSource doorSound;

    void OnTriggerEnter(Collider c)
    {
        if (isLocked || !c.tag.Equals("Player")) return;
        OpenDoor(c);
    }

    void OnTriggerExit(Collider c)
    {
        if (isLocked || !c.tag.Equals("Player")) return;
        CloseDoor(c);
    }

    protected virtual void OpenDoor(Collider c)
    {
        doorSound.Play();
    }

    protected virtual void CloseDoor(Collider c)
    {
        if (isLocked) return;
        doorSound.Play();
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
