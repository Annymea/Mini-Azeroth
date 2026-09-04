using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float damage;


    public float DoDamage()
    {
        return damage;
    }
}
