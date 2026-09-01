using UnityEngine;
using UnityEngine.Events;

//Ich möchte eine Art State Machine bauen. 
/*
 * Ich möchte es so umbauen, dass dieser controller auch von den anderen Controllern weiß und diese abfrage und nicht mehr alles Event getrieben ist
 * Außerdem möchte ich sowas wie den Cooldown eindeutig in den CombatController packen
 * Movement soll auch aus dem Controller raus
 * 
 * Die AI soll nur sagen
 * bewegt sich der Gegner grade?
 * Greift er gerade an?
 * 
 */

public class EnemyAIController : MonoBehaviour
{
    private enum movingStates
    {
        moveToPlayer, moveToSpawn, dontMove, dead, attacking, attackCooldown
    };

    [Header("Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float attackDelay = 0.3f;

    [Header("Components")]
    [SerializeField] private Rigidbody2D body;


    private movingStates moveState = movingStates.dontMove;
    private Transform player = null;
    private Vector2 spawnPos;

    private bool playerInAttackRange;
    private bool playerInSight;
    private float attackTimer;


    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void Update()
    {
        if (moveState == movingStates.attackCooldown)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                Attack();
            }
        }
    }

    private void FixedUpdate()
    {
        switch (moveState)
        {
            case movingStates.dead:
            case movingStates.dontMove:
            case movingStates.attacking:
            case movingStates.attackCooldown:
                StopMoving();
                break;

            case movingStates.moveToPlayer:
                MoveTo(player.position, stoppingDistance);
                break;

            case movingStates.moveToSpawn:
                MoveTo(spawnPos, stoppingDistance);
                break;
        }
    }




    public void OnEnterAttackRange()
    {
        if (moveState == movingStates.dead)
            return;

        playerInAttackRange = true;

        StartAttack();
    }

    public void OnExitAttackRange()
    {
        playerInAttackRange = false;
    }

    private void StartAttack()
    {
        if (moveState == movingStates.attacking ||
            moveState == movingStates.attackCooldown)
            return;

        BeginAttackCooldown();
    }

    private void BeginAttackCooldown()
    {
        moveState = movingStates.attackCooldown;
        attackTimer = attackDelay;
    }


    private void Attack()
    {
        moveState = movingStates.attacking;
        Debug.Log("Wolf greift an!");
    }

    public void OnAttackFinished()
    {
        if (moveState == movingStates.dead)
            return;

        if (playerInAttackRange)
        {
            BeginAttackCooldown();
        }
        else if (playerInSight)
        {
            moveState = movingStates.moveToPlayer;
        }
        else
        {
            moveState = movingStates.moveToSpawn;
        }
    }

    public void OnEnemySight(Transform player)
    {
        if (moveState == movingStates.dead)
            return;

        this.player = player;
        playerInSight = true;

        if (moveState != movingStates.attacking)
            moveState = movingStates.moveToPlayer;
    }

    public void OnEnemyOutOfSight()
    {
        if (moveState == movingStates.dead)
            return;

        playerInSight = false;

        if (moveState != movingStates.attacking)
            moveState = movingStates.moveToSpawn;
    }

    public void OnGetAttacked(Transform player)
    {
        if (moveState == movingStates.dead)
            return;

        this.player = player;
        if (moveState != movingStates.attacking)
            moveState = movingStates.moveToPlayer;
    }

    public void OnDeath()
    {
        moveState = movingStates.dead;
    }

    private void StopMoving()
    {
        body.linearVelocity = Vector2.zero;
    }

    private void MoveTo(Vector2 to, float tolarance)
    {
        Vector2 from = body.position;
        Vector2 direction = to - from;

        if (Vector2.Distance(from, to) < tolarance)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }

        body.linearVelocity = direction.normalized * moveSpeed;
    }
}
