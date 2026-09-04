using UnityEngine;

interface IPlayerAttack
{
    float AttackDamage();
    Transform GetPlayerPos();
}

interface IPlayerRangedAttack
{
    void Shoot(Vector2 direction, Transform player);
}

public class RangedSpellController : MonoBehaviour, IPlayerAttack, IPlayerRangedAttack
{
    [SerializeField] private float castDuration;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private float attackDamage;
    [SerializeField] private float range;
    [SerializeField] private bool destroyOnHit;
    [SerializeField] private float velocity;
    
    [Header("Components")]
    [SerializeField] private Rigidbody2D body;

    private float travelTime = 0f;
    private Transform playerPos;

    private void Update()
    {
        travelTime += Time.deltaTime;
        if (travelTime * velocity >= range)
        {
            Destroy(gameObject);
        }
    }

    public float GetCastDuration()
    {
        return castDuration;
    }

    public float GetCooldownDuration()
    {
        return cooldownDuration;
    }

    public float AttackDamage()
    {
        return attackDamage;
    }

    public Transform GetPlayerPos()
    {
        return playerPos;
    }

    public void Shoot(Vector2 direction, Transform player)
    {
        playerPos = player;
        body.linearVelocity = direction.normalized * velocity;
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
        switch (collision.tag)
        {
            case "Player":
            case "Projectile":
                return false;
            default:
                return true;
        }
    }
}
