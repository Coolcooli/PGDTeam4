using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    public void PlayAudio(float playDuration)
    {
        source.Play();
        Invoke("StopAudio", playDuration);
    }

    public void StopAudio()
    {
        source.Stop();
    }
}
