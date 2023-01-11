using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFade : MonoBehaviour
{
    private void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        GetComponent<Animator>().Play("FadeIn");
    }

    public void ManualFade()
    {
        GetComponent<Animator>().Play("FadeIn");
    }
}
