using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent (typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private bool isMoving = false;
    public bool IsMoving => isMoving;
    private bool isSprinting = false;
    private float sprintMultiplier = 1f;
    public float SprintMultiplier { set { sprintMultiplier = value; } }
    public bool IsSprinting => isSprinting;
    private bool isJumpPressed;
    public bool IsJumpPressed { get { return isJumpPressed; } set { isJumpPressed = value; } }
    private bool isCrouchPressed;
    public bool IsCrouchPressed => isCrouchPressed;

    [SerializeField]
    private float jumpForce = 10;
    public float JumpForce { get { return jumpForce; } }

    private Vector3 movementDirection;
    public Vector3 MovementDirection { get { return movementDirection; } set { movementDirection = value; } }

    private Vector3 velocity;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }
    public float Gravity { get { return .3f; } }
    public bool IsGrounded => characterController.isGrounded;

    [SerializeField]
    private float landSpeed = 5;
    [SerializeField]
    private float waterSpeed = 3;
    public float WaterSpeed { get { return waterSpeed; } }

    private Camera playerCamera;
    private Player player;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        player = GetComponent<Player>();
        playerCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 movement = ConvertMoveDirection();
        characterController.Move(movement * Time.deltaTime);

        characterController.Move(velocity * Time.deltaTime);
    }

    /// <summary>
    /// Applies input from jump key
    /// </summary>
    /// <param name="context">Value jump key</param>
    public void OnJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }

    /// <summary>
    /// Applies input from jump key
    /// </summary>
    /// <param name="context">Value jump key</param>
    public void OnCrouch(InputAction.CallbackContext context)
    {
        isCrouchPressed = context.ReadValueAsButton();
    }

    /// <summary>
    /// Apply movement from the keys
    /// </summary>
    /// <param name="context">Vector2 that contains input</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input.magnitude > 0)
            isMoving = true;
        else
            isMoving = false;
        movementDirection = new Vector3(input.x, 0, input.y);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    /// <summary>
    /// Returns movement vector based on if the player is inside the water
    /// </summary>
    private Vector3 ConvertMoveDirection()
    {
        if (player.IsInWater)
        {
            return (movementDirection.x * transform.right + movementDirection.z * playerCamera.transform.forward) * waterSpeed * sprintMultiplier;
        }
        else
        {
            return (movementDirection.x * transform.right + movementDirection.z * transform.forward) * landSpeed * sprintMultiplier;
        }
    }
}
