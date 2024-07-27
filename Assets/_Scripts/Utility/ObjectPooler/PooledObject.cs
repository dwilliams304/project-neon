using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PooledObject
{
    public GameObject ObjectToPool;
    public int AmountToPool;
    public bool WillGrow;
    public List<GameObject> currentPool;


    public PooledObject(GameObject _objectToPool, int _amountToPool, bool _willGrow){
        ObjectToPool = _objectToPool;
        AmountToPool = _amountToPool;
        WillGrow = _willGrow;
        currentPool = new List<GameObject>();
    }


    public void InstantiateObjectPool(GameObject parentObj){
        for(int i = 0; i < AmountToPool; i++){
            GameObject newObject = GameObject.Instantiate(ObjectToPool);
            newObject.transform.position = parentObj.transform.position;
            newObject.transform.rotation = parentObj.transform.rotation;
            currentPool.Add(newObject);
            newObject.SetActive(false);
            newObject.transform.parent = parentObj.transform;
        }
    }


    public GameObject GetPooledObject(Vector3 spawnPos, Quaternion rotation){
        for(int i = 0; i < currentPool.Count; i++){
            GameObject currentObj = currentPool[i];
            if(!currentObj.activeInHierarchy){
                currentObj.SetActive(true);
                currentObj.transform.position = spawnPos;
                currentObj.transform.rotation = rotation;
                return currentObj;
            }
        }
        
        if(WillGrow){
            GameObject newObject = GameObject.Instantiate(ObjectToPool);
            currentPool.Add(newObject);
            return newObject;
        }
        Debug.LogWarning($"Tried to get a Pooled Object, either they are all active and the list can't grow, or there is none.");
        return null;
    }

}
