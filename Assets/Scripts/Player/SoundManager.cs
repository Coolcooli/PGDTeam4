using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sounds;

    private Dictionary<string, AudioSource> audioSources = new Dictionary<string, AudioSource>();

    private void Start(){
        StoreSounds();
    }

    /// <summary>
    /// function that sets the items from the array in a dictionary on file name index
    /// </summary>
    private void StoreSounds(){
        foreach (AudioSource sound in sounds){
            Debug.Log(sound.name);
            audioSources.Add(sound.name, sound);
        }
    }

    public void Play(string name)
    {
        audioSources[name].Play();
    }

    /// <summary>
    /// checks if a specific audio is playing
    /// </summary>
    /// <param name="name">name of the audio source</param>
    /// <returns>whether the audio is playing or not, returns false and a warning when not found </returns>
    public bool isPlaying(string name){
        if(audioSources[name] != null)
        return audioSources[name].isPlaying;

        Debug.LogWarning("audio " + name + " doesn't exist so it can't be playing");
        return false;
    }

    public void Stop(string name){
        audioSources[name].Stop();
    }
}
