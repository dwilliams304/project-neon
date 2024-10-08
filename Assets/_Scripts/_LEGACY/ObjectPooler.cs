// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// //This list will likely become a lot more extensive, and will have more descriptive names!
// //Might need to break into multiple enums for enemies, bullets, etc, and just have a more vague PooledObjectType enum
// public enum PooledObjectType {
//     PlayerBullet_1,
//     EnemyBullet_1,
//     Enemy_1,
//     DamageText_1
// }

// public class ObjectPooler : MonoBehaviour
// {
//     public static ObjectPooler Instance;
//     public static bool UseExperimental;

//     //Make it a little easier to create a new pooled object instead of having to make all different vars for each unique obj
//     [System.Serializable]
//     public class PooledObject {
//         public GameObject objectToPool;
//         public int amountToPool;
//         public PooledObjectType pooledObjectType;
//         public List<GameObject> currentObjectPool;
//         public bool willGrow;
//     }


//     [Header("Generic Pooled Objects")]
//     [SerializeField] private List<PooledObject> pooledObjects;

//     [Header("Specific Object Attributes")]
//     [SerializeField] private Color critColor;
//     [SerializeField] private Color nonCritColor;
    

//     void Awake(){
//         Instance = this;
//     }

//     void Start(){
//         //Loop through every kind of PooledObject we want, instantiate, and set inactive
//         for(int i = 0; i < pooledObjects.Count; i++){
//             PooledObject cur = pooledObjects[i];
//             for(int j = 0; j < cur.amountToPool; j++){
//                 GameObject obj = Instantiate(cur.objectToPool);
//                 if(cur.pooledObjectType == PooledObjectType.DamageText_1){
//                     obj.transform.SetParent(gameObject.transform, false);
//                 }
//                 else{
//                     obj.transform.parent = gameObject.transform; //make scene hierarchy neater

//                 }

//                 obj.SetActive(false);
//                 cur.currentObjectPool.Add(obj);
//             }
//         }
//     }


//     //Use for Generic Pooled Objects
//     public GameObject GetPooledObject(PooledObjectType objType, int damageAmountToShow = 0, bool damageWasCrit = false){
//         for(int i = 0; i < pooledObjects.Count; i++){ 
//             var cur = pooledObjects[i];

//             //Go through every PooledObject we created, and find the matching object type
//             if(cur.pooledObjectType == objType){
//                 //If successful, loop through the object's current list of pooled objects
//                 for(int j = 0; j < cur.currentObjectPool.Count; j++){
//                     if(!cur.currentObjectPool[j].activeInHierarchy){
//                         //if not in use/inactive, return that object and set it active (why would I want an inactive one? -- might change in case)

//                         // Debug.Log($"Successfuly found object of type {objType!}");
//                         cur.currentObjectPool[j].SetActive(true);

//                         if(objType == PooledObjectType.DamageText_1){
//                             TMP_Text textComponent = cur.currentObjectPool[j].GetComponentInChildren<TMP_Text>();
//                             textComponent.text = damageAmountToShow.ToString();
//                             if(damageWasCrit){
//                                 textComponent.color = critColor;
//                             }
//                             else{
//                                 textComponent.color = nonCritColor;
//                             }
//                         }

//                         return cur.currentObjectPool[j];
//                     }
//                 }
//                 //If we couldn't find any inactive objects as they're in use, but we are okay making more of that object
//                 //return the new object we create, and then add it to the pool
//                 if(cur.willGrow){
//                     GameObject newObject = Instantiate(cur.objectToPool);
//                     newObject.transform.parent = gameObject.transform;
//                     cur.currentObjectPool.Add(newObject);
//                     // Debug.Log($"Successfuly found object of type {objType!}, and created a new one.");

//                     if(objType == PooledObjectType.DamageText_1){
//                         TMP_Text textComponent = newObject.GetComponent<TMP_Text>();
//                         textComponent.text = damageAmountToShow.ToString();
//                         if(damageWasCrit){
//                             textComponent.color = critColor;
//                         }
//                         else{
//                             textComponent.color = nonCritColor;
//                         }
//                     }
//                     return newObject;
//                 }

//                 //DO NOT NEED THIS, JUST FOR DEBUGGING
//                 else {
//                     Debug.LogWarning($"Cannot spawn anymore objects of type {objType}, as we reached the limit.");
//                     return null;
//                 }
//             }
//         }
//         //Couldn't even find anything that matches the type of object requested -- SAD !
//         Debug.LogError($"Couldn't find an object of type {objType} - FIX THIS!");
//         return null;
//     }

// }
