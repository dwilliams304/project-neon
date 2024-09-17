using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ContradictiveGames
{
    [CreateAssetMenu(fileName = "Loot Pool", menuName = "NPCs/Loot Pool")]
    public class LootPool : ScriptableObject
    {
        public int TotalLootDrops = 1;
        public List<Loot> lootTable = new List<Loot>(); //Need to switch to a loot object
    }
}
