using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject enemySprite;
    [SerializeField] private GameObject deadBody;
    [SerializeField] private GameObject enemyVision;
    [SerializeField] private Collider2D enemyCollider;

    public void OnDeath()
    {
        healthBar.SetActive(false);
        enemySprite.SetActive(false);
        enemyVision.SetActive(false);
        enemyCollider.enabled = false;

        deadBody.SetActive(true);
    }

    public void OnDespawn()
    {
        Destroy(gameObject);
    }
}
