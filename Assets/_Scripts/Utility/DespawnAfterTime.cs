using System.Collections;
using UnityEngine;

public class DespawnAfterTime : MonoBehaviour
{
    private WaitForSeconds despawnTimer;
    [SerializeField] private float waitTime;
    [SerializeField] private bool destroyObject;


    private void OnEnable(){
        despawnTimer = new WaitForSeconds(waitTime);
        StartCoroutine(Despawn());
    }

    private void OnDisable(){
        StopCoroutine(Despawn());
    }



    private IEnumerator Despawn(){
        yield return despawnTimer;
        if (!destroyObject) {
            gameObject.SetActive(false);
        }
        else{
            Destroy(gameObject);
        }
    }
}
