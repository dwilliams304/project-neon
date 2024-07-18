using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody rb;
    private void Start() => rb = GetComponent<Rigidbody>();


    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable d)){
            d.OnDamage();
        }
        gameObject.SetActive(false);
    }


    private void OnDisable(){
        rb.velocity = Vector3.zero;
    }
}
