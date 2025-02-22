using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryZone : MonoBehaviour
{
    private ObjectCarry objectCarry;
    private PlayerMovement occupyingPlayer = null;
    private bool isOccupied = false;

    void Start()
    {
        objectCarry = GetComponentInParent<ObjectCarry>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (occupyingPlayer == null && other.CompareTag("Player") && !isOccupied)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null && !objectCarry.IsPlayerAssigned(playerMovement))
            {
                occupyingPlayer = playerMovement;
                playerMovement.SetInteractableObject(objectCarry);
                isOccupied = true;
                
                Debug.Log(playerMovement.playerType + " entered CarryZone.");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null && player == occupyingPlayer)
            {
                if (!objectCarry.IsPlayerAssigned(player)) // Only clear if not carrying
                {
                    occupyingPlayer.SetInteractableObject(null);
                    occupyingPlayer = null;
                    isOccupied = false;
                    
                    Debug.Log("Player exited CarryZone.");
                }
            }
        }
        
    }
}
