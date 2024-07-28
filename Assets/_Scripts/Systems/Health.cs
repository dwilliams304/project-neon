using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public delegate void OnUnitDeath();
    public OnUnitDeath onUnitDeath;

    [Header("Health Values")]
    public Stat MaxHealth;
    private int currentHealth;
    [Space]
    [SerializeField] private bool invincible;

    [Header("UI Elements")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private bool hasHealthBar;

    [Space(10)]
    [SerializeField] private bool showsDamageText;
    [SerializeField] private Vector3 damageTextRandomOffset;


    private void Start(){
        currentHealth = (int)MaxHealth.Value;
        if(healthBar == null && hasHealthBar){
            healthBar = GetComponentInChildren<Slider>();
            UpdateHealthBarMax((int)MaxHealth.Value, true);
        }
    }

    public void TakeDamage(int amount, bool wasCrit){
        if(!invincible){
            currentHealth -= amount;
            if(hasHealthBar) UpdateHealthBarCurrent(currentHealth);
            if(showsDamageText){
                Vector3 randomPos = new Vector3(
                    Random.Range(-damageTextRandomOffset.x, damageTextRandomOffset.x),
                    damageTextRandomOffset.y,
                    Random.Range(-damageTextRandomOffset.z, damageTextRandomOffset.z)
                ) + gameObject.transform.position;
                Experimental_ObjectPooler.Instance.Pooled_Damage_Text.GetPooledTextObject(
                    randomPos, amount.ToString(), wasCrit);




                //------ LEGACY CODE -------\\

                // GameObject textObj = ObjectPooler.Instance.GetPooledObject(PooledObjectType.DamageText_1, amount, wasCrit);
                // textObj.transform.position = gameObject.transform.position + randomPos;

            }
        }
        if(currentHealth <= 0){
            onUnitDeath?.Invoke();
        }
    }

    public void TakeHeal(int amount){
        currentHealth += amount;
        if(currentHealth >= (int)MaxHealth.Value){
            currentHealth = (int)MaxHealth.Value;
        }
        if(hasHealthBar) UpdateHealthBarCurrent(currentHealth);
    }

    public void IncreaseMaxHealth(int amount, bool setCurHealthToMax = false){
        MaxHealth.AddAugment(new StatAugment(amount, StatAugmentType.Flat_Add, 1, this));
        if(setCurHealthToMax){
            currentHealth = (int)MaxHealth.Value;
        }
        if(hasHealthBar) UpdateHealthBarMax((int)MaxHealth.Value, setCurHealthToMax);
    }

    private void UpdateHealthBarMax(int amount, bool setCurToMax = false){
        healthBar.maxValue = amount;
        if(setCurToMax) healthBar.value = amount;
    }

    private void UpdateHealthBarCurrent(int amount){
        healthBar.value = amount;
    }

}
