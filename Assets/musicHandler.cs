using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicHandler : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] private AudioClip looppart;

    private void Start(){
        source = GetComponent<AudioSource>();
        StartCoroutine(Switch());
    }

    /// <summary>
    /// changes the song after it's finished
    /// </summary>
    IEnumerator Switch(){
        yield return new WaitForSeconds(31);
        source.clip = looppart;
        source.Play();
    }
}
