using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3.5f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float alertDuration = 3f;
    public LayerMask playerLayer, obstacleLayer;
    public Transform player1, player2;
    public SpriteRenderer spriteRenderer;

    private int currentPatrolIndex = 0;
    private bool isChasing = false;
    private bool isAlerted = false;
    private bool playerHidden = false;
    private Transform targetPlayer;
    private bool player1Downed = false;
    private bool player2Downed = false;

    void Start()
    {
        spriteRenderer.color = Color.green; // Default patrol color
    }

    void Update()
    {
        if (isChasing)
        {
            spriteRenderer.color = Color.red;
            ChasePlayer();
        }
        else if (isAlerted)
        {
            spriteRenderer.color = Color.yellow;
        }
        else
        {
            spriteRenderer.color = Color.green;
            Patrol();
        }

        CheckForPlayers();
    }

    void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    void CheckForPlayers()
    {
        if (playerHidden) return; // Players are hiding, do not detect

        Transform closestPlayer = GetClosestPlayer();
        if (closestPlayer == null) return;
        
        if ((closestPlayer == player1 && player1Downed) || (closestPlayer == player2 && player2Downed))
        {
            return; // Ignore downed players
        }

        Vector2 direction = (closestPlayer.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, closestPlayer.position);
        
        Debug.DrawRay(transform.position, direction * distance, Color.blue);

        if (distance <= detectionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, obstacleLayer);
            if (hit.collider == null || hit.collider.gameObject == closestPlayer.gameObject)
            {
                isChasing = true;
                targetPlayer = closestPlayer;
            }
            else
            {
                isChasing = false; // Stop chasing if an obstacle is in the way
            }
        }
    }

    Transform GetClosestPlayer()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.position);
        
        if (!player1Downed && !player2Downed)
        {
            return distanceToPlayer1 < distanceToPlayer2 ? player1 : player2;
        }
        else if (!player1Downed)
        {
            return player1;
        }
        else if (!player2Downed)
        {
            return player2;
        }
        return null;
    }

    void ChasePlayer()
    {
        if (targetPlayer == null || Vector2.Distance(transform.position, targetPlayer.position) > detectionRange)
        {
            StartCoroutine(GoBackToPatrol());
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, chaseSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPlayer.position) < attackRange)
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Player hit!");
        // Implement player defeat logic here
        PlayerMovement playerMovement = targetPlayer.GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.GetDowned();
            if (targetPlayer == player1)
                player1Downed = true;
            else if (targetPlayer == player2)
                player2Downed = true;
        }
        StartCoroutine(GoBackToPatrolAfterAttack());
    }
    
    IEnumerator GoBackToPatrolAfterAttack()
    {
        isChasing = false;
        isAlerted = true;
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(alertDuration);
        isAlerted = false;
        targetPlayer = null;
        Patrol();
    }

    IEnumerator GoBackToPatrol()
    {
        isChasing = false;
        isAlerted = true;
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(alertDuration);
        isAlerted = false;
    }

    public void PlayerHid()
    {
        playerHidden = true;
        StartCoroutine(TemporaryAlert());
    }

    public void PlayerUnhid()
    {
        playerHidden = false;
    }

    IEnumerator TemporaryAlert()
    {
        isChasing = false;
        isAlerted = true;
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(alertDuration);
        isAlerted = false;
    }
    
    public void NotifyPlayerRevived(Transform player)
    {
        if (player == player1)
            player1Downed = false;
        else if (player == player2)
            player2Downed = false;
    }
}
