using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    [SerializeField] private Transform turretHead;

    private bool preventInput = false;

    private Camera mainCam;

    void OnEnable() => UIManager.Instance.onPreventPlayerInput += PreventInput;
    void OnDisable() => UIManager.Instance.onPreventPlayerInput -= PreventInput;


    private void Start(){
        mainCam = Camera.main;
    }

    private void Update(){
        if(preventInput) return;
        Aim();
    }

    public void PreventInput(bool _preventInput){
        preventInput = _preventInput;
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
