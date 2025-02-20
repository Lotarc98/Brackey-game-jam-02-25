using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarry : MonoBehaviour
{
    public Color objectCarriedColor = Color.green;
    public Color defaultColor = Color.white;
    private SpriteRenderer spriteRenderer;

    private PlayerMovement player1;
    private PlayerMovement player2;
    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
    }
    public void AssignPlayer(PlayerMovement player)
    {
        if (Vector2.Distance(player.transform.position, transform.position) > 1.5f) 
            return;

        if (player1 == null)
        {
            player1 = player;
            Debug.Log("Player 1 assigned to carry object.");
        }
        else if (player2 == null)
        {
            player2 = player;
            Debug.Log("Player 2 assigned to carry object.");
        }
        
        UpdateObjectState();
    }

    public void UnassignPlayer(PlayerMovement player)
    {
        if (player1 == player)
        {
            player1 = null;
            Debug.Log("Player 1 dropped the object.");
        }
        else if (player2 == player)
        {
            player2 = null;
            Debug.Log("Player 2 dropped the object.");
        }
        
        UpdateObjectState();
    }
    
    public bool IsPlayerAssigned(PlayerMovement player)
    {
        return player1 == player || player2 == player;
    }

    private void UpdateObjectState()
    {
        bool isBeingCarried = (player1 != null && player2 != null);

        spriteRenderer.color = isBeingCarried ? objectCarriedColor : defaultColor;

        if (player1 != null) player1.SetCarrying(isBeingCarried);
        if (player2 != null) player2.SetCarrying(isBeingCarried);

        Debug.Log("Object Carrying State: " + isBeingCarried);
    }

    void Update()
    {
        if (player1 != null && player2 != null)
        {
            if (Vector2.Distance(player1.transform.position, player2.transform.position) < 3f) // Ensure players stay close
            {
                Vector3 midpoint = (player1.transform.position + player2.transform.position) / 2;
                transform.position = midpoint; // Object stays between both players
                Debug.Log("Object moving to: " + midpoint);
            }
            else
            {
                Debug.Log("Players are too far apart, object will not move.");
            }
        }
    }
    
}
