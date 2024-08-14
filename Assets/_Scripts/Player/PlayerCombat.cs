using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerCombat : MonoBehaviour, IDamageable
{
    private bool preventInput;

    public PlayerStats playerStats;

    [Header("Other vars")]
    [SerializeField] private int magazineSize; //TO-DO: GET THIS VALUE FROM A PLAYERSTATS CLASS
    [SerializeField] private int currentAmmo;

    [SerializeField] private bool isReloading;
    [SerializeField] private bool infiniteAmmo; //TO-DO: MAKE THIS VALUE CHANGEABLE FROM POWER-UPS/ABILITIES
    
    [SerializeField] private WaitForSeconds reloadSpeedWait; //TO-DO: GET THIS VALUE FROM A PLAYERSTATS CLASS

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
        preventInput = false;
        playerStats = GetComponent<PlayerStats>();
        currentAmmo = magazineSize;
        health = GetComponent<Health>();
        reloadSpeedWait = new WaitForSeconds(playerStats.ReloadSpeed.Value);
        PlayerHUDUI.Instance.UpdateAmmoText(currentAmmo, magazineSize);
    }

    private void Update(){
        if(preventInput) return;

        if(!isReloading && Input.GetButton("Fire1")){
            Shoot();
        }
        if(!isReloading && Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(Reload());
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
            if(!infiniteAmmo) {
                currentAmmo--;
                PlayerHUDUI.Instance.UpdateAmmoText(currentAmmo, magazineSize);
            }
            EffectsManager.Instance.CameraShake(1.5f, 0.05f);
        }
    }


    private IEnumerator Reload(){
        isReloading = true;
        yield return reloadSpeedWait;
        currentAmmo = magazineSize;
        PlayerHUDUI.Instance.UpdateAmmoText(currentAmmo, magazineSize);
        isReloading = false;
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
