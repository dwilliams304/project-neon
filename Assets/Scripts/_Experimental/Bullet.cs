using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private void Start() => rb = GetComponent<Rigidbody>();

    private void OnCollisionEnter(Collision collision){
        Debug.Log("Bullet collided, despawning");
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
