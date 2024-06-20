using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;

    private void Start(){
        rb = GetComponentInChildren<Rigidbody>();

        if(!rb) {
            Debug.Log("Could not find a RigidBody on player character!");
        }
    }

    private void Update(){
        MovePlayer();
    }

    private void MovePlayer(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveY).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // rb.AddForce(movement * moveSpeed);
    }
}
