using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public delegate void OnUnitDeath();
    public OnUnitDeath onUnitDeath;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool invincible;

    private void Start(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount){
        if(!invincible){
            currentHealth -= amount;
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
    }


}
