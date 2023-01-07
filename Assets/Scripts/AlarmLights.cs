using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLights : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> lights = new List<GameObject>();

    private new List<Light> light = new List<Light>();
    private List<Animation> animations = new List<Animation>();

    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        for (int i = 0; i < lights.Count; i++)
        {
            light.Add(lights[i].GetComponentInChildren<Light>());
            animations.Add(lights[i].GetComponent<Animation>());
        }
    }

    public void AlarmOn()
    {
        audioSource.Play();
        for(int i = 0; i < lights.Count; i++)
        {
            light[i].enabled = true;
            animations[i].Play();
        }
    }

    public void AlarmOf()
    {
        audioSource.Stop();
        for (int i = 0; i < animations.Count; i++)
        {
            light[i].enabled = false;
            animations[i].Stop();
        }
    }
}
