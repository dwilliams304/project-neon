using System.Collections.Generic;
using UnityEngine;

namespace ContradictiveGames.AI
{
    [CreateAssetMenu(fileName = "NPC Data", menuName = "NPCs/NPC Data")]
    public class NPCData : ScriptableObject
    {
        [Header("Base NPC Info")]
        public string NpcName = "Default Name";
        public bool IsFriendly = false;
        public bool IsDamageable = true;
        public bool CanHeal = false;

        [Header("Movement")]
        public Stat MoveSpeed = new Stat(7f);


        [Header("Health")]
        public int MaxHealth = 100;
        public Stat DamageTakenModifier = new Stat(1f);
        public Color HealthBarColor = Color.red;


        [Header("Combat")]
        public Stat AttackSpeed = new Stat(0.5f);
        public Stat BaseDamage = new Stat(10f);


        [Header("Loot Pool")]
        public int CurrencyDrop = 10;
        public int XPDrop = 10;
        public int CorruptionDrop = 10;
        public List<GameObject> LootPool = new List<GameObject>();


        [Header("Misc")]
        public bool UsesHealthBar = true;
        public bool ShowsDamageText = true;
    }    
}