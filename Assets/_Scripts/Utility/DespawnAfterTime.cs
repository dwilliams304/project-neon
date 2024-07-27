using UnityEngine;

public class DespawnAfterTime : MonoBehaviour
{

    [SerializeField] private float waitTime;
    [SerializeField] private bool destroyObject;

    private float timeActivated;


    private void OnEnable() {
        timeActivated = Time.time;
    }


    private void Update(){
        if(Time.time > timeActivated + waitTime){
            gameObject.SetActive(false);
        }
    }

}
