using UnityEngine;

public class GeneralEnemyController : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameObject healthBarContainer;

    private HealthbarController healthBar;

    private void Awake()
    {
        healthBar = healthBarContainer.GetComponent<HealthbarController>();
        healthBar.setMaxHealth(maxHealth);
        healthBar.DoDamage(10);
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
        Debug.Log("Au");
    }
}
