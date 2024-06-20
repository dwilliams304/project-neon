using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform turretHead;

    private Camera mainCam;

    private void Start(){
        mainCam = Camera.main;
    }

    private void Update(){
        Aim();
    }


    private void Aim(){
        var (success, mousePos) = GetMousePosition();
        if(success){
            var dir = mousePos - turretHead.position;

            dir.y = 0;
            turretHead.forward = dir;
        }
    }

    private (bool success, Vector3 mousePos) GetMousePosition(){
        var ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, ground)){
            return(success: true, mousePos: hitInfo.point);
        }
        else{
            return(success:false, mousePos: Vector3.zero);
        }
    }
}
