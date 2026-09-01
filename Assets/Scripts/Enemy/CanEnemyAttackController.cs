using UnityEngine;
using UnityEngine.Events;

public class CanEnemyAttackController : MonoBehaviour
{
    public UnityEvent canAttack;
    public UnityEvent stopAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
        canAttack.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
        stopAttack.Invoke();
    }
}
