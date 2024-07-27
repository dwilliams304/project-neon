using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class PooledTextObject
{
    public GameObject ObjectToPool;
    public int AmountToPool;
    public bool WillGrow;
    public List<GameObject> currentPool;

    public Color Color_Normal;
    public Color Color_Special;


    public PooledTextObject(GameObject _objectToPool, int _amountToPool, bool _willGrow){
        ObjectToPool = _objectToPool;
        AmountToPool = _amountToPool;
        WillGrow = _willGrow;
        currentPool = new List<GameObject>(AmountToPool);
    }

    public void InstantiateObjectPool(GameObject parentObj){
        for(int i = 0; i < AmountToPool; i++){
            GameObject newObject = GameObject.Instantiate(ObjectToPool);
            currentPool.Add(newObject);
            newObject.SetActive(false);
            newObject.transform.SetParent(parentObj.transform);
        }
    }


    public GameObject GetPooledTextObject(Vector3 spawnPos, string textToShow, bool useSpecialColor){
        for(int i = 0; i < currentPool.Count; i++){
            GameObject currentObj = currentPool[i];
            if(!currentObj.activeInHierarchy){
                currentObj.SetActive(true);
                TMP_Text textElement = currentObj.GetComponentInChildren<TMP_Text>();
                textElement.text = textToShow;
                if(useSpecialColor) textElement.color = Color_Normal;
                else textElement.color = Color_Special;
                currentObj.transform.position = spawnPos;
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
