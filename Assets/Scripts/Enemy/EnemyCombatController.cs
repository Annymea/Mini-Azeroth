using UnityEngine;

public class EnemyCombatController : MonoBehaviour
{
    private enum CombatState
    {
        idle,//is not attacking 
        prepare, //prepare for first attack 
        beginAttack, //approach the player and give him time to dodge
        attack, //attack and spawn the collider
        finishAttack, //go back to position
        cooldown //cooldown -> before next attack
    }

    [Header("Stats")]
    [SerializeField] private float attackDamage;
    [SerializeField] private float cooldown;
    [SerializeField] private float prepare;
    //[SerializeField] private float attackDuration = 0.2f; 

    [Header("Components")]
    [SerializeField] private GameObject attack;
    [SerializeField] private EnemyAnimationController animate;


    private CombatState state = CombatState.idle;
    private bool isAttacking = false;
    private float cooldownTimer = 0;
    private float prepareTimer = 0;

    private Transform player;
    private Vector2 attackPosition;
    private Vector2 enemyPosition;
    private bool started = false;

    private void Update()
    {
        //Debug.Log(state);
        switch (state)
        {
            case CombatState.idle:
                break; 
            case CombatState.prepare:
                prepareTimer += Time.deltaTime;

                if (prepareTimer >= prepare)
                {
                    prepareTimer = 0;
                    state = CombatState.beginAttack;
                    isAttacking = true;
                }
                break;

            case CombatState.beginAttack:
                if (!started)
                {
                    Debug.Log(attackPosition);
                    enemyPosition = transform.position;
                    attackPosition = player.position;
                    animate.BeginAttackPlayer(attackPosition);
                    started = true;
                }
                break;

            case CombatState.attack:
                attack.SetActive(true);
                attack.transform.position = attackPosition;
                state = CombatState.finishAttack;
                break;

            case CombatState.finishAttack:
                attack.SetActive(false);
                animate.EndAttackPlayer(enemyPosition);
                break;

            case CombatState.cooldown:
                cooldownTimer += Time.deltaTime;
                //Debug.Log($"Cooldown: {cooldownTimer}");

                if (cooldownTimer >= cooldown)
                {
                    cooldownTimer = 0;
                    state = CombatState.prepare;
                }
                break;
        }
    }

    public void OnAttackBegan()
    {
        state = CombatState.attack;
        started = false;
    }

    public void OnAttackFinished()
    {
        state = CombatState.cooldown; 
        isAttacking = false;
    }


    public bool IsAttacking()
    {
        return isAttacking;
    }

    public void TryAttack(Transform player)
    {
        this.player = player;
        if(state == CombatState.idle)
            state = CombatState.prepare;
    }

    public void Stop()
    {
        state = CombatState.idle;
    }


}
