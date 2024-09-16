using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "Default Rarity", menuName = "Custom/Rarity")]
public class Rarity : ScriptableObject
{
    public string RarityName = "Default Rarity";

    public int PercentDropChance = 50;
    public Color RarityColor = Color.white;

    public List<GameObject> LootTable = new List<GameObject>(); //Change object type to a lootobject eventually

    public GameObject DropPrefab;
}

[CustomEditor(typeof(Rarity))]
public class RarityEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
}