using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    [SerializeField]private GameObject[] UI;//list of UI that needs to get activated again

    	
    /// <summary>
    /// function that closes the pause screen
    /// </summary>
    public void Resume(){

        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1;


        Debug.Log(UI.Length);
        foreach(GameObject UIobj in UI){
            if(UIobj == transform.parent.gameObject) continue;

            UIobj.SetActive(true);
        }

        transform.parent.gameObject.SetActive(false);
    }
}
