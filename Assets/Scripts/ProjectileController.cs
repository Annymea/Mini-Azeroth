using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float velocity;

    public void Shoot(Vector2 direction)
    {
        body.linearVelocity = direction.normalized * velocity;
        Debug.Log("direction: " +  direction);
        Debug.Log("linearVel: " + body.linearVelocity);
    }
}
