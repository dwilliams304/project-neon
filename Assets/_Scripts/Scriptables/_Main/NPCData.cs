using UnityEngine;
using ContradictiveGames.Loot;

namespace ContradictiveGames.AI
{
    public enum ThinkingSpeed {
        None, //Does not think
        Fast, //Short ticks
        Normal, //Normal ticks
        Slow, //Every 2nd normal tick
        Slowest //Every fifth normal tick
    }

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
        [Min(0)]
        public int MaxHealth = 100;
        public Stat DamageTakenModifier = new Stat(1f);
        public Color HealthBarColor = Color.red;


        [Header("Combat")]
        public Stat AttackSpeed = new Stat(0.5f);
        public Stat BaseDamage = new Stat(10f);
        [Min(0)]
        public float AttackRange = 1f;
        [Min(0)]
        public float FollowRange = 2f;


        [Header("Loot Pool")]
        [Min(0)]
        public int CurrencyDrop = 10;
        [Min(0)]
        public int XPDrop = 10;
        [Min(0)]
        public int CorruptionDrop = 10;
        public LootPool lootPool;


        [Header("Misc")]
        public bool UsesHealthBar = true;
        public bool ShowsDamageText = true;
        [Tooltip("Whether or not the NPC will do things on ticks/updates. If checked false, will not do anything")]
        public bool IsStaticNpc = false;
        [Tooltip("Which tick speed this NPC will subscribe to. \n None - Does not do any update logic \n Fast - Every short tick \n Normal - Every normal tick \n Slow - Every 2nd normal tick \n Slowest - Every 5th normal tick")]
        public ThinkingSpeed thinkingSpeed = ThinkingSpeed.Normal;
        [Tooltip("If the main target is the player. Allows for pet NPCs, Healer Enemies, etc...")]
        public bool PlayerIsTarget = true;
    }    
}