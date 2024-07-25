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

    [Space(10)]
    [SerializeField] private bool showsDamageText;
    [SerializeField] private Vector3 damageTextRandomOffset;


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
            if(showsDamageText){
                Vector3 randomPos = new Vector3(
                    Random.Range(-damageTextRandomOffset.x, damageTextRandomOffset.x),
                    damageTextRandomOffset.y,
                    Random.Range(-damageTextRandomOffset.z, damageTextRandomOffset.z)
                );
                int roll = Random.Range(0, 101);
                bool wasCrit = false;
                if(roll >= 50){
                    wasCrit = true;
                }
                GameObject textObj = ObjectPooler.Instance.GetPooledObject(PooledObjectType.DamageText_1, amount, wasCrit);
                textObj.transform.position = gameObject.transform.position + randomPos;

            }
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
        if(hasHealthBar) UpdateHealthBarCurrent(currentHealth);
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
