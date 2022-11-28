using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_02 : MonoBehaviour
{
    [SerializeField]
    private Animation wing;
    [SerializeField]
    private bool isLocked;

    void OnTriggerEnter(Collider c)
    {
        if (isLocked) return;

        if (c.tag.Equals("Player"))
        {
            GetComponent<AudioSource>().Play();
            wing["door_02_wing"].speed = 1;
            wing.Play();
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (isLocked) return;

        if (c.tag.Equals("Player"))
        {
            GetComponent<AudioSource>().Play();
            wing["door_02_wing"].time = wing["door_02_wing"].length;
            wing["door_02_wing"].speed = -1;
            wing.Play();
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
