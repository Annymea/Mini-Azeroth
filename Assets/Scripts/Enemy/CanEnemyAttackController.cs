using UnityEngine;

public class CanEnemyAttackController : MonoBehaviour
{

    private bool canAttack = false;

    public bool CanAttack()
    {
        return canAttack;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
        canAttack = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
        canAttack = false;
    }
}
