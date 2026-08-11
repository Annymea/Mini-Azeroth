using UnityEngine;

public class GeneralEnemyController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private GameObject healthBarContainer;
    [SerializeField] private GameObject deadBody;

    private HealthbarController healthBar;

    private void Awake()
    {
        healthBar = healthBarContainer.GetComponent<HealthbarController>();
        healthBar.setMaxHealth(maxHealth);
    }

    private void Update()
    {

        if (healthBar.GetMaxHealth() == healthBar.GetCurrentHealth())
        { 
            healthBar.showHealthbar(false);
            
        }
        else
        {
            healthBar.showHealthbar(true);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject attack = collision.gameObject;
        AttackController attackController = attack.GetComponent<AttackController>();
        if (attackController == null)
            return;

        healthBar.DoDamage(attackController.GetDamage());

        if (!healthBar.IsAlive())
        {
            Instantiate(deadBody, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            Destroy(gameObject);
        }
    }
}
