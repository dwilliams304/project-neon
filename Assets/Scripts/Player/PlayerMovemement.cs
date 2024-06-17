using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update(){
        MovePlayer();
    }

    private void MovePlayer(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveY).normalized;

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
