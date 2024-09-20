using System.Collections;
using UnityEngine;

namespace ContradictiveGames.Player
{
    [RequireComponent(typeof(PlayerStats))]
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        
        private Rigidbody rb;
        private PlayerStats playerStats;
        
        private float moveX;
        private float moveZ;
        private Vector3 moveDirection;    
        private float timeSinceLastDash;
        WaitForSeconds dashDurationWait;
        private bool isDashing;

        // private DashTrailAnimatior dashTrailAnimatior;



        private void Start(){
            rb = GetComponent<Rigidbody>();
            if(rb == null) Debug.LogError("No Rigidbody found on component, FIX THIS!");
            isDashing = false;
            playerStats = GetComponent<PlayerStats>();
            dashDurationWait = new WaitForSeconds(playerStats.DashDuration.Value);
            timeSinceLastDash = Time.time - playerStats.DashCooldown.Value;
            // dashTrailAnimatior = GetComponent<DashTrailAnimatior>();
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
            rb.velocity = moveDirection * playerStats.MoveSpeed.Value;
        }


        private bool CanDash(){
            if(!isDashing && Time.time > timeSinceLastDash + playerStats.DashCooldown.Value) return true;
            else return false;
        }


        private IEnumerator Dash(){
            isDashing = true;
            timeSinceLastDash = Time.time;
            rb.velocity = moveDirection * playerStats.DashSpeed.Value;
            // dashTrailAnimatior.StartTrailEffect(DashDuration.Value);
            yield return dashDurationWait;
            isDashing = false;
        }

    }
}