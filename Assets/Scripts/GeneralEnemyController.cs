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
}
