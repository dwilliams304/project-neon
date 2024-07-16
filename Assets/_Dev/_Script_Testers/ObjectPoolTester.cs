using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTester : MonoBehaviour
{
    public PooledObjectType pooledObjectType;


    void Update(){
        if(Input.GetKeyDown(KeyCode.P)){
            ObjectPooler.Instance.GetPooledObject(pooledObjectType);
        }
    }
}
