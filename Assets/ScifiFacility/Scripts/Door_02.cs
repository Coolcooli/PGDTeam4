using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_02 : MonoBehaviour
{
    [SerializeField]
    private Animation wing;

    void OnTriggerEnter(Collider c)
    {
        if (c.tag.Equals("Player"))
        {
            GetComponent<AudioSource>().Play();
            wing["door_02_wing"].speed = 1;
            wing.Play();
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag.Equals("Player"))
        {
            GetComponent<AudioSource>().Play();
            wing["door_02_wing"].time = wing["door_02_wing"].length;
            wing["door_02_wing"].speed = -1;
            wing.Play();
        }
    }
}
