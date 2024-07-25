using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private bool preventInput = false;

    [SerializeField] private float fireRate;
    [SerializeField] private float projectileSpeed;
    
    [SerializeField] private int magazineSize;
    [SerializeField] private int currentAmmo;

    [SerializeField] private bool isReloading;
    [SerializeField] private bool infiniteAmmo;
    [SerializeField] private WaitForSeconds reloadSpeed;

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
        if(currentAmmo > 0 && (Time.time > timeSinceLastShot + fireRate)){
            timeSinceLastShot = Time.time;
            GameObject bullet = ObjectPooler.Instance.GetPooledObject(PooledObjectType.PlayerBullet_1);
            if(bullet == null) return;
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.up * projectileSpeed, ForceMode.Impulse);
            if(!infiniteAmmo) currentAmmo--;
        }
    }

}
