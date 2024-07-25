using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody rb;

    [Header("Move Speed")]
    [SerializeField] private float moveSpeed;
    private float moveX;
    private float moveZ;
    private Vector3 moveDirection;

    [Header("Dash Variables")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    
    private float timeSinceLastDash;
    WaitForSeconds dashDurationWait;
    private bool isDashing;


    private void Start(){
        rb = GetComponent<Rigidbody>();
        if(rb == null) Debug.LogError("No Rigidbody found on component, FIX THIS!");
        isDashing = false;
        dashDurationWait = new WaitForSeconds(dashDuration);
        timeSinceLastDash = Time.time;
    }


    private void Update(){
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if(Input.GetButtonDown("Jump") && CanDash()){
            StartCoroutine(Dash());
        }
        
    }


    private void FixedUpdate(){
        if(isDashing) return;
        rb.velocity = moveDirection * moveSpeed;
    }


    private bool CanDash(){
        if(!isDashing && Time.time > timeSinceLastDash + dashCooldown) return true;
        else return false;
    }


    private IEnumerator Dash(){
        isDashing = true;
        timeSinceLastDash = Time.time;
        rb.velocity = moveDirection * dashSpeed;
        yield return dashDurationWait;
        isDashing = false;
    }

}
