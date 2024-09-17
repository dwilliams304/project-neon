using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContradictiveGames
{
    public enum LootType {
        Augment,
        PowerUp,
        Ability,
        Multi
    }

    [CreateAssetMenu(fileName = "Loot", menuName = "Custom/Loot")]
    public class Loot : ScriptableObject
    {
        public int ChanceToCorrupt = 0; //0 - 1000 (allows for 0.1% chance)

        public Rarity rarity;

        public LootType lootType = LootType.Multi;
    }
}