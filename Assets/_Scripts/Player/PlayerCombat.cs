using UnityEngine;

public class PlayerCombat : MonoBehaviour, IDamageable
{
    private bool preventInput = false;

    [Header("Combat Stats")]
    public Stat Damage;
    public Stat Damage_Taken_Multiplier;
    public Stat CritChance;
    public Stat CritDamageMultiplier;
    public Stat FireRate;
    public Stat ProjectileSpeed;
    public Stat ReloadSpeed;


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
        if(currentAmmo > 0 && (Time.time > timeSinceLastShot + FireRate.Value)){
            timeSinceLastShot = Time.time;
            GameObject bullet_exp = Experimental_ObjectPooler.Instance.Pooled_Bullet.GetPooledObject(firePoint.position, firePoint.rotation);
            if(bullet_exp == null) return;
            bullet_exp.GetComponent<Rigidbody>().AddForce(firePoint.up * ProjectileSpeed.Value, ForceMode.Impulse);
            if(!infiniteAmmo) currentAmmo--;
        }
    }


    /*  -----------------------------------------------------------------
        |                       PLACEHOLDER!!!!!                        |
        |  Will change in the future, so that the enemy passes their    |
        | damage stats / multipliers and whatnot, this does not yet     |
        |                  TODO: USE ENEMY STAT VALS!!!                 |
        -----------------------------------------------------------------
    */
    public void OnDamage()
    {
        health.TakeDamage(Mathf.FloorToInt(GameManager.Instance.CalculateDamage() * Damage_Taken_Multiplier.Value), false);
    }
}
