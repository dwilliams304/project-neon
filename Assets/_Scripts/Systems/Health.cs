using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public delegate void OnUnitDeath();
    public OnUnitDeath onUnitDeath;

    [Header("Health Values")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool invincible;

    [Header("UI Elements")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private bool hasHealthBar;

    private void Start(){
        currentHealth = maxHealth;
        if(healthBar == null && hasHealthBar){
            healthBar = GetComponentInChildren<Slider>();
            UpdateHealthBarMax(maxHealth, true);
        }
    }

    public void TakeDamage(int amount){
        if(!invincible){
            currentHealth -= amount;
            if(hasHealthBar) UpdateHealthBarCurrent(currentHealth);
        }
        if(currentHealth <= 0){
            onUnitDeath?.Invoke();
        }
    }

    public void TakeHeal(int amount){
        currentHealth += amount;
        if(currentHealth >= maxHealth){
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxHealth(int amount, bool setCurHealthToMax = false){
        maxHealth += amount;
        if(setCurHealthToMax){
            currentHealth = maxHealth;
        }
        if(hasHealthBar) UpdateHealthBarMax(maxHealth, setCurHealthToMax);
    }

    void UpdateHealthBarMax(int amount, bool setCurToMax = false){
        healthBar.maxValue = amount;
        if(setCurToMax) healthBar.value = amount;
    }

    void UpdateHealthBarCurrent(int amount){
        healthBar.value = amount;
    }

}
