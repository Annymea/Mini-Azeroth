using Unity.VisualScripting;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackRange;
    [SerializeField] private float stoppingDistance;

    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D body;

    private bool moveToPlayer = false;
    private Transform player = null;

    private void FixedUpdate()
    {
        if (moveToPlayer)
        {
            MoveTo(player.position, attackRange);
        }
        //Later: if not in sight anymore move to spawnerPos
    }

    public void OnEnemySight(Transform player)
    {
        moveToPlayer = true;
        this.player = player;
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
