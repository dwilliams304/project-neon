using System.Collections;
using UnityEngine;
using ContradictiveGames.Experimental;
using ContradictiveGames.Managers;
using ContradictiveGames.UI;

namespace ContradictiveGames.Player
{
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

        private Experimental_ObjectPooler objPInsance;


        private Health health;


        private void Awake(){
            playerStats = GetComponent<PlayerStats>();
            health = GetComponent<Health>();
        }


        private void OnEnable(){
            UIManager.Instance.onPreventPlayerInput += PreventInput;
            health.onDeath += OnDeath;
        }


        private void OnDisable(){
            UIManager.Instance.onPreventPlayerInput -= PreventInput;
            health.onDeath -= OnDeath;
        }


        private void Start(){
            preventInput = false;
            currentAmmo = magazineSize;
            reloadSpeedWait = new WaitForSeconds(playerStats.ReloadSpeed.Value);
            PlayerUI.Instance.UpdateAmmoText(currentAmmo, magazineSize);
            objPInsance = Experimental_ObjectPooler.Instance;
        }


        private void Update(){
            if(preventInput) return;

            if(!isReloading && Input.GetButton("Fire1")){
                Shoot();
            }
            else if(!isReloading && Input.GetKeyDown(KeyCode.R)){
                StartCoroutine(Reload());
            }
        }


        private void PreventInput(bool _preventInput){
            preventInput = _preventInput;
        }


        private void Shoot(){
            if(currentAmmo > 0 && (Time.time > timeSinceLastShot + playerStats.FireRate.Value)){
                timeSinceLastShot = Time.time;
                GameObject bullet_exp = objPInsance.Pooled_Bullet.GetPooledObject(firePoint.position, firePoint.rotation);
                if(bullet_exp == null) return;
                bullet_exp.GetComponent<Rigidbody>().AddForce(firePoint.up * playerStats.ProjectileSpeed.Value, ForceMode.Impulse);
                if(!infiniteAmmo) {
                    currentAmmo--;
                    PlayerUI.Instance.UpdateAmmoText(currentAmmo, magazineSize);
                }
                EffectsManager.Instance.CameraShake(1.5f, 0.05f);
            }
            if(currentAmmo < 7){
                PlayerUI.Instance.ShowLowAmmoAlert(true);
            }
        }


        private IEnumerator Reload(){
            isReloading = true;
            yield return reloadSpeedWait;
            currentAmmo = magazineSize;
            PlayerUI.Instance.ShowLowAmmoAlert(false);
            PlayerUI.Instance.UpdateAmmoText(currentAmmo, magazineSize);
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


        private void OnDeath(){
            Debug.Log("Player dead! Sad!");
        }

    }
}