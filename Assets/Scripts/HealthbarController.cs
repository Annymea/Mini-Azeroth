using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject background;

    private int maxHealth = 100; 
    private int currentHealth = 100;
    private float healthPercentage;

    private void Update()
    {
        healthPercentage = (float)currentHealth / (float)maxHealth; 
    }

    private void FixedUpdate()
    {
        healthBar.transform.localScale = new Vector3(healthPercentage, 1, 1);
    }

    public void setMaxHealth(int maxHealth)
    {
        int maxHealthDiff = this.maxHealth - maxHealth;

        this.maxHealth = maxHealth;
        currentHealth -= maxHealthDiff;
    }

    public void DoDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
            currentHealth = 0;
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public void showHealthbar(bool show)
    {
        healthBar.SetActive(show);
        background.SetActive(show);
    }
}
