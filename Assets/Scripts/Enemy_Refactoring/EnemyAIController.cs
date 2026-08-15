using UnityEngine;
using UnityEngine.Events;

public class EnemyAIController : MonoBehaviour
{
    private enum movingStates
    {
        moveToPlayer, moveToSpawn, dontMove, dead
    };

    [Header("Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float stoppingDistance;

    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D body;


    private movingStates moveState = movingStates.dontMove;
    private Transform player = null;
    private Vector2 spawnPos; //last position before running to player

    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void FixedUpdate()
    {
        switch (moveState){
            case movingStates.dead:
                body.linearVelocity = Vector3.zero;
                break;
            case movingStates.dontMove:
                body.linearVelocity = Vector3.zero;
                break;
            case movingStates.moveToPlayer:
                MoveTo(player.position, attackRange);
                break;
            case movingStates.moveToSpawn:
                MoveTo(spawnPos, stoppingDistance);
                break;
            default:
                break;
        }
    }

    public void OnEnemySight(Transform player)
    {
        if (moveState == movingStates.dead)
            return;

        this.player = player;
        moveState = movingStates.moveToPlayer;
    }

    public void OnEnemyOutOfSight()
    {
        if (moveState == movingStates.dead)
            return;

        moveState = movingStates.moveToSpawn;
    }

    public void OnDeath()
    {
        moveState = movingStates.dead;
    }

    public void MoveTo(Vector2 to, float tolarance)
    {
        Vector2 from = body.position;
        Vector2 direction = to - from;

        if ((from - to).magnitude < tolarance)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }

        body.linearVelocity = direction.normalized * moveSpeed;
    }
}
