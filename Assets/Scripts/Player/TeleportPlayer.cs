using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Teleport(Vector3 destination)
    {
        controller.enabled = false;
        player.transform.position = destination;
        controller.enabled = true;
    }

    void Teleport(Vector3 destination, string scene)
    {
        controller.enabled = false;
        SceneManager.LoadScene(scene);
        player.transform.position = destination;
        controller.enabled = true;
    }
}
