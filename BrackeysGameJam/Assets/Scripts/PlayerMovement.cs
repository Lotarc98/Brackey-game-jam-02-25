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
    private Animator animator;
    
    [Header("Input Actions")]
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction reviveAction;
    
    private ObjectCarry interactableObject;

    private bool isCarrying = false;
    private bool isDowned = false;
    
    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();

        if (playerType == PlayerType.Player1)
        {
            moveAction = playerInput.actions["OnMovePlayer1"];
            interactAction = playerInput.actions["InteractPlayer1"];
            reviveAction = playerInput.actions["RevivePlayer1"];
        }
        else if (playerType == PlayerType.Player2)
        {
            moveAction = playerInput.actions["OnMovePlayer2"];
            interactAction = playerInput.actions["InteractPlayer2"];
            reviveAction = playerInput.actions["RevivePlayer2"];
        }
    }

    void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        interactAction.performed += OnInteract;
        interactAction.canceled += OnInteract;
        reviveAction.performed += OnRevive;
    }

    void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        interactAction.performed -= OnInteract;
        interactAction.canceled -= OnInteract;
        reviveAction.performed -= OnRevive;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        if (isDowned) return; // If downed, prevent movement
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
            
            animator.SetBool("IsCarrying", true);
        } 
        if (context.canceled) // When button is released
        {
            Debug.Log(playerType + " released interact button.");
            interactableObject.UnassignPlayer(this);
            
            animator.SetBool("IsCarrying", false);
        }

    }
    
    private void OnRevive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
            foreach (Collider2D collider in hitColliders)
            {
                PlayerMovement otherPlayer = collider.GetComponent<PlayerMovement>();
                if (otherPlayer != null && otherPlayer.isDowned)
                {
                    otherPlayer.Revive();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isDowned) return; // Stop movement if downed
        
        
        float currentSpeed = isCarrying ? carryingSpeed : normalSpeed;
        Vector2 targetVelocity = moveInput * currentSpeed;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref smoothVelocity, accelerationTime);
        
        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Magnitude", moveInput.sqrMagnitude);
    }
    
    public void GetDowned()
    {
        isDowned = true;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic; // Prevent movement from collisions
        //rb.simulated = false; // Disable physics interactions
        playerInput.enabled = false; // Disable input when downed
        
        animator.SetBool("IsDowned", true);
        animator.SetTrigger("Downed");
    }

    public void Revive()
    {
        if (!isDowned) return;
        
        isDowned = false;
        rb.bodyType = RigidbodyType2D.Dynamic; // Restore movement
        //rb.simulated = true;
        moveInput = Vector2.zero;
        rb.velocity = Vector2.zero;
        playerInput.enabled = true;
        
        animator.SetBool("IsDowned", false);
        animator.SetTrigger("Revive");

        // Notify the enemy AI that this player has been revived
        FindObjectOfType<EnemyAI>().NotifyPlayerRevived(transform);
    }

    public void SetInteractableObject(ObjectCarry obj)
    {
        interactableObject = obj;
    }
    
    public void SetCarrying(bool carrying)
    {
        isCarrying = carrying;
        animator.SetBool("IsCarrying", carrying);
        Debug.Log(playerType + " speed set to " + (carrying ? carryingSpeed : normalSpeed));
    }

    public bool IsDowned()
    {
        return isDowned;
    }
}
