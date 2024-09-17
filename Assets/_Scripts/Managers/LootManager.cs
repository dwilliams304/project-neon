using System.Collections.Generic;
using UnityEngine;
using ContradictiveGames.Loot;
using ContradictiveGames.Player;

namespace ContradictiveGames.Managers
{
    public class LootManager : MonoBehaviour
    {
        public static LootManager Instance;
        
        public List<Rarity> rarities;


        [SerializeField] private int totalWeights = 0;

        private Stat luckStat;

        private void Awake(){
            Instance = this;
        }


        private void Start(){
            luckStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().LuckStat;
            for(int i = 0; i < rarities.Count; i++){
                totalWeights += rarities[i].Weight;
            }
        }


        public int Editor_GetTotalWeights(){
            totalWeights = 0;
            for(int i = 0; i < rarities.Count; i++){
                totalWeights += rarities[i].Weight;
            }
            return totalWeights;
        }

        public void SortRarites(){
            rarities.Sort(delegate(Rarity a, Rarity b){
                return a.Weight.CompareTo(b.Weight);
            });
        }


        public void DropLoot(Vector3 spawnPos, List<LootPool> lootPool = null){
            int roll = Random.Range(0, totalWeights + 1);
            int starterRoll = roll; //DEBUG ONLY
            // roll /= 1 + (int)luckStat.Value;

            Rarity rarity = ChooseRarity(roll);

            /*  IF WE WANT TO HAVE GLOBAL LOOT POOLS
            if(lootPool == null){
                DropLootFromGlobal(spawnPos, rarity.LootTable);
            }
            
                TO USE FOR WHEN DOING PERSONAL LOOT POOLS
            for(int i = 0; i < lootPool.TotalLootDrops; i++){
                -Loop through loot table
                    -Check to see if the current loot drop's rarity in the loot table matches
                        -if so, spawn that object
                
                -if no loot matching that rarity drops, ???
            }
            
            */

            //SpawnLoot(rarity.DropPrefab, spawnPos)

            Debug.Log($"Rolled a {starterRoll}, and got a(n) {rarity.RarityName} drop!"); //DEBUG ONLY
        }


        /*
        private int Roll(){
            return Random.Range(0, totalWeights + 1);
        }

        private void SpawnLoot(GameObject lootObjPrefab, LootData lootData, Vector3 spawnPos)
        {
            -Get the LootObject componenet (will exist) from the GameObject
            -Set the LootObject's data to be the data we want
            -Spawn the prefab where we want
        }
        */


        private Rarity ChooseRarity(int roll){
            for(int i = 0; i <= rarities.Count; i++){
                var rarity = rarities[i];
                if(roll <= rarity.Weight){
                    return rarity; //DEBUG ONLY
                }
                else{
                    roll -= rarity.Weight;
                }
            }
            return null;
        }

    }
}
