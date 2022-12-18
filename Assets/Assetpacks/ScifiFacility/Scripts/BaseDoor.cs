using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDoor : MonoBehaviour
{
    [SerializeField]
    protected List<Animation> wings;

    [SerializeField]
    private bool isLocked;

    public bool IsLocked { get => isLocked; }

        [SerializeField]
    private AudioSource doorSound;

    void OnTriggerEnter(Collider c)
    {
        if (isLocked || c.tag != "Player") return;
        OpenDoor();
    }

    void OnTriggerExit(Collider c)
    {
        if (isLocked || c.tag != "Player") return;
        CloseDoor();
    }

    protected virtual void OpenDoor()
    {
        doorSound.Play();
    }

    protected virtual void CloseDoor()
    {

        doorSound.Play();
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }

    public virtual void ToggleLock()
    {
        Debug.Log(isLocked);
        isLocked = !isLocked;
    }
}
