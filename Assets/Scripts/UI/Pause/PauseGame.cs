using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField]private GameObject pauseUI;

    	
    /// <summary>
    /// function that pauses the game
    /// </summary>
    public void Pause(){
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;

        GameObject[] UI = GameObject.FindGameObjectsWithTag("UI");

        foreach(GameObject UIobj in UI){

            UIobj.SetActive(false);
        }

        pauseUI.SetActive(true);

    }
}
