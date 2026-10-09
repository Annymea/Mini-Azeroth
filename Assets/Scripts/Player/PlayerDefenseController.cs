using UnityEngine;
using UnityEngine.Events;

public class PlayerDefenseController : MonoBehaviour
{
    public UnityEvent<float> playerDamaged;
    [SerializeField] private AudioClip[] damageSounds;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "EnemyAttack")
            return;

        EnemyAttackController attack = collision.GetComponent<EnemyAttackController>();
        if (attack == null) return;

        playerDamaged.Invoke(attack.EnemyAttackDmg());
        SoundManager.instance.PlayRandomClip(damageSounds, transform, 100f);
    }


}
