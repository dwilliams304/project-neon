using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Loot Pool", menuName = "NPCs/Loot Pool")]
public class LootPool : ScriptableObject
{
    public int TotalLootDrops = 1;
    public List<GameObject> lootTable = new List<GameObject>(); //Need to switch to a loot object
}
