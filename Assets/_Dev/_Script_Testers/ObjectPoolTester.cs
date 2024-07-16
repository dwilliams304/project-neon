using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
    [SerializeField] private PooledObjectType pooledObjectType;
    [SerializeField] private KeyCode keyToSpawn;


    void Update(){
        if(Input.GetKeyDown(keyToSpawn)){
            ObjectPooler.Instance.GetPooledObject(pooledObjectType);
        }
    }
}
