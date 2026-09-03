using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    [SerializeField] private float dmg;

    public float EnemyAttackDmg()
    {
        return dmg;
    }
}
