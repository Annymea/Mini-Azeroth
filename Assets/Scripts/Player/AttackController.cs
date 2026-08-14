using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float damage;
    public float DoDamage()
    {
        Debug.Log(damage);
        return damage;
    }
}
