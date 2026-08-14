using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject enemySprite;
    [SerializeField] private GameObject deadBody;
    [SerializeField] private GameObject enemyVision; 

    public void OnDeath()
    {
        healthBar.SetActive(false);
        enemySprite.SetActive(false);
        enemyVision.SetActive(false);

        deadBody.SetActive(true);
    }
}
