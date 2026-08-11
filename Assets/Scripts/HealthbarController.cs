using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject background;

    private float maxHealth = 100; 
    private float currentHealth = 100;
    private float healthPercentage;

    private void Update()
    {
        healthPercentage = currentHealth / maxHealth; 
    }

    private void FixedUpdate()
    {
        healthBar.transform.localScale = new Vector3(healthPercentage, 1, 1);
    }

    public void setMaxHealth(float maxHealth)
    {
        float maxHealthDiff = this.maxHealth - maxHealth;

        this.maxHealth = maxHealth;
        currentHealth -= maxHealthDiff;
    }

    public void DoDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
            currentHealth = 0;
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
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
