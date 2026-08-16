using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float velocity;
    [SerializeField] private float range;
    [SerializeField] private bool destroyOnHit;

    private float travelTime = 0f;
    private Transform playerPos;

    public void SetPlayerPos(Transform player)
    {
        playerPos = player;
    }

    public Transform GetPlayerPos()
    {
        return playerPos;
    }

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
        

        if (IsHittable(collision) == false)
            return;

        if (destroyOnHit)
        { 
            Destroy(gameObject);
        }
            
    }

    private bool IsHittable(Collider2D collision)
    {
        bool isPlayer = collision.gameObject.GetComponentInChildren<PlayerController>() != null;
        bool isOtherProjectile = collision.gameObject.GetComponentInChildren<ProjectileController>() != null;

        return !(isPlayer || isOtherProjectile);
    }
}
