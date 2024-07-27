using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CharacterAugment", menuName = "Custom/Augments", order = 0)]
public class CharacterAugment : ScriptableObject
{
    public List<StatAugment> augments;

    public void AddAugment(){
        for(int i = 0; i < augments.Count; i++){
            //AddAugment(this)
        }
    }

    public void RemoveAugment(){
        //RemoveAllModifiersFromSource(this);
    }

}
