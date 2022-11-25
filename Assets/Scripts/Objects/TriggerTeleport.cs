using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTeleport : MonoBehaviour
{
    [SerializeField]
    public Vector3 destination;
    public string scene;
    private CharacterController controller;
    public GameObject player;

    private void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(scene != "")
        {
            controller.enabled = false;
            SceneManager.LoadScene(scene);
            player.transform.position = destination;
            controller.enabled = true;

        } else
        {
            controller.enabled = false;
            player.transform.position = destination;
            controller.enabled = true;
        }
    }
}
