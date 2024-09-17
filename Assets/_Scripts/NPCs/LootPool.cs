using System.Collections.Generic;
using UnityEngine;

namespace ContradictiveGames.Loot
{
    [CreateAssetMenu(fileName = "Loot Pool", menuName = "NPCs/Loot Pool")]
    [System.Serializable]
    public class LootPool : ScriptableObject
    {
        public int TotalLootDrops = 1;
        public List<LootDrop> LootTable; //Need to switch to a loot object
        // private void Awake(){
        //     LootTable = new List<Loot>();
        // }

        public LootPool(int _totalDrops, List<LootDrop> loot){
            TotalLootDrops = _totalDrops;
            LootTable = loot;
        }
    }
}
