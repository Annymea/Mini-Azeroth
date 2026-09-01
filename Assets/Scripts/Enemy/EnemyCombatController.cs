using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float attackDamage;
    [SerializeField] private float cooldown;

    private bool isAttacking = false;
    private float cooldownTimer = 0;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public void TryAttack(Transform player)
    {
        if(cooldownTimer >= cooldown)
        {
            Debug.Log("Attack");
            cooldownTimer = 0;
        }
    }

    public void Stop()
    {
        Debug.Log("Stop Attack");
    }


}
