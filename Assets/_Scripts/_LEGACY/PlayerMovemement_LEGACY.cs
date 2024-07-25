using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemement_LEGACY : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    float moveX;
    float moveY;
    Vector3 movement;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    private float timeSinceLastDash;
    WaitForSeconds dashDurationTimer;

    private bool isDashing;

    private Rigidbody rb;

    private void Start(){
        rb = GetComponentInChildren<Rigidbody>();
        dashDurationTimer = new WaitForSeconds(dashDuration);

        if(!rb) {
            Debug.Log("Could not find a RigidBody on player character!");
        }
    }

    private void Update(){
        MovePlayer();

        if(Input.GetButtonDown("Jump") && CanDash()){
            StartCoroutine(Dash());
        }
    }

    // private void FixedUpdate(){
    //     rb.velocity = new Vector3(moveX * moveSpeed, 0f, moveY * moveSpeed).normalized;
    // }

    private bool CanDash(){
        if(!isDashing && Time.time > timeSinceLastDash + dashCooldown) return true;
        else return false;
    }



    private void MovePlayer(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveX, 0f, moveY).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // rb.AddForce(movement * moveSpeed);
    }


    private IEnumerator Dash(){
        isDashing = true;
        timeSinceLastDash = Time.time;
        transform.Translate(movement * dashSpeed);
        yield return dashDurationTimer;
        isDashing = false;
    }
}
