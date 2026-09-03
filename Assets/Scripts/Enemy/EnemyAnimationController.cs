using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimationController : MonoBehaviour
{
    private enum CombatState
    {
        idle, beginAttack, finishAttack
    }
    [Header("Attack Animation")]
    [SerializeField] private float movingTolerance = 0.02f;
    [SerializeField] private float attackMoveSpeed = 0.002f;
    [SerializeField] private float attackStopDistance = 1f;

    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Events")]
    public UnityEvent attackBegan; //Event after finishing beginning attack animation
    public UnityEvent attackFinished; //Event after finishing beginning attack animation

    private CombatState state;
    private Vector2 playerPosition;
    private Vector2 enemyPosition; 

    private void Update()
    {
        animator.SetFloat("VelocityX", Mathf.Abs(body.linearVelocityX));
        animator.SetFloat("VelocityY", Mathf.Abs(body.linearVelocityY));

        if(body.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(body.linearVelocityX > 0)
        {
            spriteRenderer.flipX = false;
        }

        switch (state) 
        {
            case CombatState.beginAttack:
                if (MoveSpriteTo(playerPosition, attackStopDistance))
                {
                    attackBegan.Invoke();
                    state = CombatState.idle;
                }
                break;
            case CombatState.finishAttack:
                if (MoveSpriteTo(enemyPosition, 0))
                {
                    attackFinished.Invoke();
                    state = CombatState.idle;
                }
                break; 
        }
    }


    private bool MoveSpriteTo(Vector2 position, float stopDistance)
    {
        Vector2 from = transform.position;
        Vector2 direction = position - from;

        if (Vector2.Distance(from, position) < movingTolerance + stopDistance)
        {
            return true;
        }

        transform.position +=
            (Vector3)(direction.normalized * attackMoveSpeed * Time.deltaTime);

        return false;
    }
    public void BeginAttackPlayer(Vector2 playerPos)
    {
        playerPosition = playerPos;
        enemyPosition = transform.position;

        state = CombatState.beginAttack;
    }

    public void EndAttackPlayer(Vector2 enemyPos) 
    {
        state = CombatState.finishAttack;
    }

    public void StopCombatAnimation()
    {
        state = CombatState.idle;
    }

}
