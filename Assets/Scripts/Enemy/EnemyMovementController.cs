using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D body;

    [Header("Stats")]
    [SerializeField] private float movingTolerance;
    [SerializeField] private float moveSpeed;


    public void MoveTo(Vector2 position)
    {
        Vector2 from = body.position;
        Vector2 direction = position - from;

        if (Vector2.Distance(from, position) < movingTolerance)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }

        body.linearVelocity = direction.normalized * moveSpeed;
    }

    public void Stop()
    {
        body.linearVelocity = Vector2.zero;
    }

    public bool HasReached(Vector2 position)
    {
        if (Vector2.Distance(body.position, position) < movingTolerance)
        {
            return true;
        }
        return false;
    }
}
