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
                /*
                if(attackTime == 0)
                {
                    transform.position = new Vector2( playerPosition.x, playerPosition.y);
                    Debug.Log("EnemySpritePos " + transform.position);
                }
                attackTime += Time.deltaTime;
                if(attackTime >= attackTimer)
                {
                    attackBegan.Invoke();
                    state = CombatState.idle;
                    attackTime = 0;
                }
                */

                if (MoveSpriteTo(playerPosition))
                {
                    attackBegan.Invoke();
                    state = CombatState.idle;
                }
                break;
            case CombatState.finishAttack:

                transform.position = enemyPosition;
                //if (MoveSpriteTo(position))
                //{
                //    Debug.Log("FinishAnimation fertig");
                    attackFinished.Invoke();
                    state = CombatState.idle;
                //}
                break; 
        }
    }


    private bool MoveSpriteTo(Vector2 position)
    {
        Vector2 from = transform.position;
        Vector2 direction = position - from;

        if (Vector2.Distance(from, position) < movingTolerance + attackStopDistance)
        {
            return true;
        }

        transform.position +=
            (Vector3)(direction.normalized * attackMoveSpeed * Time.deltaTime);

        return false;
    }

    /*
    private bool MoveToPlayer(Vector2 playerPos)
    {
        Vector2 wolfPos = spriteRenderer.transform.position;
        Vector2 direction = (playerPos - wolfPos).normalized;

        if (Vector2.Distance(wolfPos, position) < attackStopDistance )
        {
            spriteRenderer.transform.position = position;
            return true;
        }

        spriteRenderer.transform.position += 
            direction.normalized * attackMoveSpeed * Time.deltaTime;

        return false; 
    }
    */
    public void BeginAttackPlayer(Vector2 playerPos)
    {
        playerPosition = playerPos;
        enemyPosition = transform.position;//new Vector2(transform.position.x, transform.position.y) ;

        //Debug.Log("BeginAnimation");
        Debug.Log("in Event" + playerPos);
        state = CombatState.beginAttack;
    }

    public void EndAttackPlayer(Vector2 enemyPos) 
    {
        //Debug.Log("FinishAnimation");
        state = CombatState.finishAttack;
    }

}
