using UnityEngine;
using UnityEngine.Events;

public class EnemyDefenseController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float defense;

    [Header("Events")]
    public UnityEvent<float> getDamage;
    public UnityEvent<Transform> getDamageFrom;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Projectile") return;

        IPlayerAttack attack = collision.GetComponent<IPlayerAttack>();
        if(attack == null) return;

        float damage = Mathf.Max(attack.AttackDamage() - defense, 0);

        getDamage.Invoke(damage);

        Transform playerPos = attack.GetPlayerPos();
        getDamageFrom.Invoke(playerPos);
    }
}
