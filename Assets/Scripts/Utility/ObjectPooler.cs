using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PooledObjectType {
    PlayerBullet_1,
    EnemyBullet_1,
    Enemy_1,
    DamageText_1
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [System.Serializable]
    public class PooledObject {
        public GameObject objectToPool;
        public int amountToPool;
        public PooledObjectType pooledObjectType;
        public List<GameObject> currentObjectPool;
        public bool willGrow;
    }


    [SerializeField] private List<PooledObject> pooledObjects;


    void Awake(){
        Instance = this;
    }

    void Start(){
        for(int i = 0; i < pooledObjects.Count; i++){
            PooledObject cur = pooledObjects[i];
            for(int j = 0; j < cur.amountToPool; j++){
                GameObject obj = Instantiate(cur.objectToPool);
                obj.transform.parent = gameObject.transform;

                obj.SetActive(false);
                cur.currentObjectPool.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(PooledObjectType objType){
        for(int i = 0; i < pooledObjects.Count; i++){
            var cur = pooledObjects[i];
            if(cur.pooledObjectType == objType){
                for(int j = 0; j < cur.currentObjectPool.Count; j++){
                    if(!cur.currentObjectPool[j].activeInHierarchy){
                        return cur.currentObjectPool[j];
                    }
                }
                if(cur.willGrow){
                    GameObject newObject = Instantiate(cur.objectToPool);
                    cur.currentObjectPool.Add(newObject);
                    return newObject;
                }
            }
        }

        Debug.LogError($"Couldn't find an object pooled of type {objType} - FIX THIS!");
        return null;
    }

}
