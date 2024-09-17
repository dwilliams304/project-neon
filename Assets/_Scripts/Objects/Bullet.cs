using UnityEngine;

namespace ContradictiveGames
{
    public class Bullet : MonoBehaviour
    {

        private Rigidbody rb;

        private void OnEnable() => rb = GetComponent<Rigidbody>();
        private void OnDisable() => rb.velocity = Vector3.zero;


        private void OnCollisionEnter(Collision collision){
            if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable d)){
                d.OnDamage();
            }
            gameObject.SetActive(false);
        }
    }
}