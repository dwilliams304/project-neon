using UnityEngine;

namespace ContradictiveGames.Loot
{
    public enum LootType {
        Augment,
        PowerUp,
        Ability,
        Multi
    }

    [CreateAssetMenu(fileName = "Loot", menuName = "Custom/Loot")]
    public class LootDrop : ScriptableObject
    {
        public string LootName = "Loot Name";

        public int ChanceToCorrupt = 0; //0 - 1000 (allows for 0.1% chance)

        public Rarity rarity;

        public LootType lootType = LootType.Multi;
    }
}