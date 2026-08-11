using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float velocity;
    [SerializeField] private float range;
    [SerializeField] private bool destroyOnHit;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.GetComponents<PlayerController>() != null; 
        bool isOtherProjectile = collision.gameObject.GetComponents<ProjectileController>() != null;
        Debug.Log(isPlayer + " ... " + isOtherProjectile );
        Debug.Log(destroyOnHit && (!isPlayer || !isOtherProjectile));

        if (isPlayer || isOtherProjectile)
            return;

        if (destroyOnHit)
        { 
            Destroy(gameObject);
        }
            
    }
}
