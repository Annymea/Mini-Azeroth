using UnityEngine;
using UnityEngine.Events;

public class HealthbarController : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject background;


    [Header("Stats")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private bool alwaysShow = false;


    [Header("Events")]
    public UnityEvent isDeadNow;


    private float currentHealth;
    private float healthPercentage;
     

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthPercentage = currentHealth / maxHealth;
        
        if(!alwaysShow)
            hideHealthbar();
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

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDeadNow.Invoke();
            currentHealth = 0;
        }
        
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    private void hideHealthbar()
    {
        if(currentHealth == maxHealth)
        {
            healthBar.SetActive(false);
            background.SetActive(false);
        }
        else
        {
            healthBar.SetActive(true);
            background.SetActive(true);
        }
        
    }
}
