using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ContradictiveGames.Loot
{
    [CreateAssetMenu(fileName = "Default Rarity", menuName = "Custom/Rarity")]
    public class Rarity : ScriptableObject
    {
        public string RarityName = "Default Rarity";

        public int Weight = 50;
        public Color RarityColor = Color.white;

        public List<LootPool> LootTable = new List<LootPool>(); //Might remove, unless we want a global loot table for certain rarities

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
}