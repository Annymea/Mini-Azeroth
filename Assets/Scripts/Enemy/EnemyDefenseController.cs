using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDefenseController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float defense;

    [Header("Events")]
    public UnityEvent<float> getDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Projectile") return;

        AttackController attack = collision.GetComponent<AttackController>();
        if (attack == null) return;

        float damage = Mathf.Max(attack.DoDamage() - defense, 0);
        getDamage.Invoke(damage);
    }
}
