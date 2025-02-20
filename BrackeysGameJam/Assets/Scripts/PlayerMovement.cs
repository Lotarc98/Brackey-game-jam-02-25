using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Speeds")]
    public float normalSpeed = 5f;
    public float accelerationTime = 0.1f;
    public float carryingSpeed = 2f; // Reduced speed when carrying
    
    
    private Vector2 smoothVelocity = Vector2.zero;
    private Vector2 moveInput;
    
    [Header("Components")]
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    
    [Header("Input Actions")]
    private InputAction moveAction;
    private InputAction interactAction;
    
    
    private ObjectCarry interactableObject;

    private bool isCarrying = false;
    
    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        if (playerType == PlayerType.Player1)
        {
            moveAction = playerInput.actions["OnMovePlayer1"];
            interactAction = playerInput.actions["InteractPlayer1"];
        }
        else if (playerType == PlayerType.Player2)
        {
            moveAction = playerInput.actions["OnMovePlayer2"];
            interactAction = playerInput.actions["InteractPlayer2"];
        }
    }

    void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        interactAction.performed += OnInteract;
        interactAction.canceled += OnInteract;
    }

    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        interactAction.performed -= OnInteract;
        interactAction.canceled -= OnInteract;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        if (interactableObject == null)
        {
            Debug.Log(playerType + " tried to interact, but no object is nearby.");
            return;
        }

        if (context.performed) // When button is pressed
        {
            Debug.Log(playerType + " pressed interact button.");
            interactableObject.AssignPlayer(this);
        } 
        if (context.canceled) // When button is released
        {
            Debug.Log(playerType + " released interact button.");
            interactableObject.UnassignPlayer(this);
        }

    }

    void FixedUpdate()
    {
        float currentSpeed = isCarrying ? carryingSpeed : normalSpeed;
        Vector2 targetVelocity = moveInput * currentSpeed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref smoothVelocity, accelerationTime);
    }

    public void SetInteractableObject(ObjectCarry obj)
    {
        interactableObject = obj;
    }
    
    public void SetCarrying(bool carrying)
    {
        isCarrying = carrying;
        Debug.Log(playerType + " speed set to " + (carrying ? carryingSpeed : normalSpeed));
    }
}
