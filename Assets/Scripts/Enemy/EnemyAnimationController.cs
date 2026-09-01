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
    [SerializeField] private float attackMoveSpeed = 5f;
    [SerializeField] private float attackStopDistance = 1f;

    [Header("Components")]
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D body;
    [SerializeField] SpriteRenderer spriteRenderer;

    [Header("Events")]
    public UnityEvent attackBegan; //Event after finishing beginning attack animation
    public UnityEvent attackFinished; //Event after finishing beginning attack animation

    private CombatState state;
    private Vector2 position;
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
                if (MoveSpriteTo(position))
                {
                    attackBegan.Invoke();
                }
                break;
            case CombatState.finishAttack:
                if (MoveSpriteTo(position))
                {
                    attackFinished.Invoke();
                }
                break; 
        }
    }

    private bool MoveSpriteTo(Vector2 position)
    {
        Vector2 from = spriteRenderer.transform.position;
        Vector2 direction = position - from;

        if (Vector2.Distance(from, position) < movingTolerance)
        {
            spriteRenderer.transform.position = position;
            return true;
        }

        spriteRenderer.transform.position +=
            (Vector3)(direction.normalized * attackMoveSpeed * Time.deltaTime);

        return false;
    }

    public void BeginAttackPlayer(Vector2 playerPos)
    {
        Vector2 wolfPos = spriteRenderer.transform.position;
        Vector2 direction = (playerPos - wolfPos).normalized;

        position = playerPos - direction * attackStopDistance;
        state = CombatState.beginAttack;
    }

    public void EndAttackPlayer(Vector2 enemyPos) 
    {
        position = enemyPos;
        state = CombatState.finishAttack;
    }

}
