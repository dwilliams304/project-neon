using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private bool preventInput = false;

    [Header("Combat Stats")]
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

    private void OnEnable(){
        UIManager.Instance.onPreventPlayerInput += PreventInput;
    }
    private void OnDisable(){
        UIManager.Instance.onPreventPlayerInput -= PreventInput;
    }

    private void Start(){
        currentAmmo = magazineSize;
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
            GameObject bullet = ObjectPooler.Instance.GetPooledObject(PooledObjectType.PlayerBullet_1);
            if(bullet == null) return;
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.up * ProjectileSpeed.Value, ForceMode.Impulse);
            if(!infiniteAmmo) currentAmmo--;
        }
    }

}
