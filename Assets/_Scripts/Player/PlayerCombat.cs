using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCombat : MonoBehaviour, IDamageable
{
    private bool preventInput = false;

    public PlayerStats playerStats;

    [Header("Combat Stats")]
    // public Stat Damage;
    // public Stat Damage_Taken_Multiplier;
    // public Stat CritChance;
    // public Stat CritDamageMultiplier;
    // public Stat FireRate;
    // public Stat ProjectileSpeed;
    // public Stat ReloadSpeed;


    [Header("Other vars")]
    [SerializeField] private int magazineSize; //TO-DO: GET THIS VALUE FROM A PLAYERSTATS CLASS
    [SerializeField] private int currentAmmo;

    [SerializeField] private bool isReloading;
    [SerializeField] private bool infiniteAmmo; //TO-DO: MAKE THIS VALUE CHANGEABLE FROM POWER-UPS/ABILITIES
    
    [SerializeField] private WaitForSeconds reloadSpeed; //TO-DO: GET THIS VALUE FROM A PLAYERSTATS CLASS

    [SerializeField] private Transform firePoint;

    private float timeSinceLastShot;


    private Health health;



    private void OnEnable(){
        UIManager.Instance.onPreventPlayerInput += PreventInput;
    }
    private void OnDisable(){
        UIManager.Instance.onPreventPlayerInput -= PreventInput;
    }

    private void Start(){
        playerStats = GetComponent<PlayerStats>();
        currentAmmo = magazineSize;
        health = GetComponent<Health>();
    }

    private void Update(){
        if(preventInput) return;

        if(!isReloading && Input.GetButton("Fire1")){
            Shoot();
        }
    }

    private void PreventInput(bool _preventInput){
        preventInput = _preventInput;
    }


    private void Shoot(){
        if(currentAmmo > 0 && (Time.time > timeSinceLastShot + playerStats.FireRate.Value)){
            timeSinceLastShot = Time.time;
            GameObject bullet_exp = Experimental_ObjectPooler.Instance.Pooled_Bullet.GetPooledObject(firePoint.position, firePoint.rotation);
            if(bullet_exp == null) return;
            bullet_exp.GetComponent<Rigidbody>().AddForce(firePoint.up * playerStats.ProjectileSpeed.Value, ForceMode.Impulse);
            if(!infiniteAmmo) currentAmmo--;
            EffectsManager.Instance.CameraShake(1.5f, 0.05f);
        }
    }


    /*  -----------------------------------------------------------------
        |                       PLACEHOLDER!!!!!                        |
        |  Will change in the future, so that the enemy passes their    |
        | damage stats / multipliers and whatnot, this does not yet     |
        |                  TODO: USE ENEMY STAT VALS!!!                 |
        -----------------------------------------------------------------
    */
    public void OnDamage(Stat damageStat)
    {
        health.TakeDamage(Mathf.FloorToInt(GameManager.Instance.CalculateDamage(damageStat) * playerStats.DamageTaken.Value), false);
    }
}
