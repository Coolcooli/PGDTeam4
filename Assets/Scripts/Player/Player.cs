using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerBaseState currentState;
    public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }

    private PlayerStateFactory states;

    [SerializeField]
    private bool isInWater = true;
    public bool IsInWater { get { return isInWater; } }

    [SerializeField] private AudioSource waterEnter;
    [SerializeField] private AudioSource waterExit;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        PlayerMovement movement = GetComponent<PlayerMovement>();

        states = new PlayerStateFactory(this, movement);
        currentState = movement.IsGrounded ? states.Grounded() : states.Jump();
        currentState.EnterState();
    }

    void Update()
    {
        currentState.UpdateStates();
    }

    /// <summary>
    /// Checks if the player in entering air
    /// </summary>
    /// <param name="other">The object that the player collides with</param>
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Air":
                isInWater = false;
                waterExit.Play();
                Debug.Log("enter");
                break;
            case "Water":
                isInWater = true;
                waterEnter.Play();
                Debug.Log("exit");
                break;
        }
    }
}