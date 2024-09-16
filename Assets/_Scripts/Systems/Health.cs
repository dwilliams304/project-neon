using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public delegate void OnDeath();
    public OnDeath onDeath;

    [Header("Health Values")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private bool isDamageable;
    [SerializeField] private bool canHeal;

    [Header("UI Elements")]
    [SerializeField] private bool usesHealthBar;
    [SerializeField] private Slider healthBar;

    [Space(10)]
    [SerializeField] private bool showsDamageText;
    [SerializeField] private Vector3 damageTextRandomOffset;


    private void Start(){
        
    }
    

    public void InitializeHealthSystem(int _maxHealth, bool _isDamageable, bool _usesHealthBar, bool _showsDamageText, bool _canHeal, Color _healthBarColor){
        isDamageable = _isDamageable;
        usesHealthBar = _usesHealthBar;
        showsDamageText = _showsDamageText;
        canHeal = _canHeal;

        if(usesHealthBar && healthBar == null){

            if(GetComponentInChildren<Slider>()){
                healthBar = GetComponentInChildren<Slider>();
                
            }
            else{
                Debug.LogError("There was no health bar, need to make one!");
            }
            healthBar.fillRect.GetComponent<Image>().color = _healthBarColor;
            
        }

        SetMaxHealth(_maxHealth, true);
    }


    private void SetMaxHealth(int amount, bool setCurToMax = false){
        maxHealth = amount;
        if(setCurToMax) currentHealth = maxHealth;
        if(usesHealthBar) UpdateHealthBarMax(maxHealth, true);
    }


    public void TakeDamage(int amount, bool wasCrit = false){
        if(isDamageable){
            currentHealth -= amount;

            if(usesHealthBar) UpdateHealthBarCurrent(currentHealth);

            if(showsDamageText){
                Experimental_ObjectPooler.Instance.Pooled_Damage_Text.GetPooledTextObject(
                    GetRandomTextOffset(transform.position), amount.ToString(), wasCrit
                );
            }
        }

        if(currentHealth <= 0) onDeath?.Invoke();
    }


    public void TakeHeal(int amount){
        if(canHeal){
            currentHealth += amount;
            if(showsDamageText){
                Experimental_ObjectPooler.Instance.Pooled_Damage_Text.GetPooledTextObject(
                    GetRandomTextOffset(transform.position), amount.ToString(), false, true
                );
            }
            if(currentHealth > maxHealth) currentHealth = maxHealth;
        }
    }


#region UI

    private void UpdateHealthBarMax(int amount, bool setCurToMax = false){
        healthBar.maxValue = amount;
        if(setCurToMax) healthBar.value = amount;
    }

    private void UpdateHealthBarCurrent(int amount){
        healthBar.value = amount;
    }


    private Vector3 GetRandomTextOffset(Vector3 objPos){
        return new Vector3(
            Random.Range(-damageTextRandomOffset.x, damageTextRandomOffset.x),
            damageTextRandomOffset.y,
            Random.Range(-damageTextRandomOffset.z, damageTextRandomOffset.z)
        ) + objPos;
    }

#endregion

}
