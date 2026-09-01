using UnityEngine;

public class EnemyStatusController : MonoBehaviour
{
    private enum EnemyState
    {
        chasePlayer, moveToSpawn, idle, dead, attack
    };

    [Header("Components")]
    [SerializeField] private EnemyCombatController combat;
    [SerializeField] private EnemyMovementController move;
    [SerializeField] private CanEnemyAttackController attackRange;

    private EnemyState state = EnemyState.idle;
    private EnemyState? requestedState = null;
    private Vector2 spawnPos; 
    private Transform player = null;

    private void Awake()
    {
        spawnPos = transform.position;
    }

    private void Update()
    {
        if (state == EnemyState.dead) return;

        CheckState();
        ExecuteState();
    }

    private void CheckState()
    {
        switch (state)
        {
            case EnemyState.idle:
                CheckIdleState();
                break;

            case EnemyState.chasePlayer:
                CheckChasePlayerState();
                break;

            case EnemyState.attack:
                CheckAttackState();
                break;

            case EnemyState.moveToSpawn:
                CheckMoveToSpawnState();
                break;

            default:
                break;
        }
    }

    private void ExecuteState()
    {
        switch (state)
        {
            case EnemyState.idle:
                move.Stop();
                break;
            case EnemyState.chasePlayer:
                move.MoveTo(player.position);
                break;
            case EnemyState.attack:
                move.Stop();
                combat.TryAttack(player);
                break;
            case EnemyState.moveToSpawn:
                move.MoveTo(spawnPos);
                break;
            default:
                move.Stop();
                break;
        }
    }

    private void ChangeState(EnemyState newState)
    {
        state = newState;
        requestedState = null;

        if (newState == EnemyState.moveToSpawn)
        {
            player = null;
        }
    }

    private void CheckMoveToSpawnState()
    {
        if (requestedState == EnemyState.chasePlayer)
        {
            ChangeState(EnemyState.chasePlayer);
            return;
        }

        if (move.HasReached(spawnPos))
        {
            ChangeState(EnemyState.idle);
            return;
        }

    }

    private void CheckAttackState()
    {
        if (combat.IsAttacking())
        {
            return;
        }

        if (requestedState == EnemyState.moveToSpawn)
        {
            ChangeState(EnemyState.moveToSpawn);
            return;
        }

        if (requestedState == EnemyState.chasePlayer)
        {
            requestedState = null;
            if (!attackRange.CanAttack())
            {
                ChangeState(EnemyState.chasePlayer);
            }
            return;
        }

        if (!attackRange.CanAttack())
        {
            ChangeState(EnemyState.chasePlayer);
        }
    }

    private void CheckIdleState()
    {
        if (requestedState == EnemyState.chasePlayer)
        {
            ChangeState(EnemyState.chasePlayer);
            return;
        }
    }

    private void CheckChasePlayerState()
    {
        if (requestedState == EnemyState.moveToSpawn)
        {
            ChangeState(EnemyState.moveToSpawn);
            return;
        }

        if (attackRange.CanAttack())
        {
            ChangeState(EnemyState.attack);
            return;
        }
    }

    public void OnStartChase(Transform player)
    {
        this.player = player;
        requestedState = EnemyState.chasePlayer;
    }

    public void OnLostPlayer()
    {
        requestedState = EnemyState.moveToSpawn;
    }

    public void OnDeath()
    {
        state = EnemyState.dead;
        requestedState = null;
        player = null;

        combat.Stop();
        move.Stop();
    }
}
