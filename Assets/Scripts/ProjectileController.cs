using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float velocity;
    [SerializeField] private float range;

    private float travelTime = 0f;

    public void Shoot(Vector2 direction)
    {
        body.linearVelocity = direction.normalized * velocity;
    }

    private void Update()
    {
        travelTime += Time.deltaTime;
        if(travelTime * velocity >= range)
        {
            Destroy(gameObject);
        } 
    }

    
}
