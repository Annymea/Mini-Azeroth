using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private float damage;
    public float GetDamage()
    {
        return damage;
    }
}
