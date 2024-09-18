using System.Collections.Generic;
using UnityEngine;
using ContradictiveGames.Loot;
using ContradictiveGames.Player;

namespace ContradictiveGames.Managers
{
    public class LootManager : MonoBehaviour
    {
        public static LootManager Instance;
        
        public List<Rarity> rarities = new List<Rarity>();


        [SerializeField] private int totalWeights = 0;

        private Stat luckStat;

        private void Awake(){
            Instance = this;
        }


        private void Start(){
            luckStat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().LuckStat;
            totalWeights = 0;
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
                return b.Weight.CompareTo(a.Weight);
            });
        }


        public void DropLoot(Vector3 spawnPos){
            Debug.Log($"Total weights: {totalWeights}");
            int roll = Random.Range(0, totalWeights + 1);
            Debug.Log(roll);
            // roll /= 1 + (int)luckStat.Value;
            Rarity _rarity = ChooseRarity(roll);

            Debug.Log($"<color=cyan>Rolled and got a(n) {_rarity.RarityName} drop!</color>"); //DEBUG ONLY
        }


        /*

        private void SpawnLoot(GameObject lootObjPrefab, LootData lootData, Vector3 spawnPos)
        {
            -Get the LootObject componenet (will exist) from the GameObject
            -Set the LootObject's data to be the data we want
            -Spawn the prefab where we want
        }
        */


        private Rarity ChooseRarity(int roll){
            for(int i = 0; i < rarities.Count; i++){
                Debug.Log($"<color=green>{roll} on loop {i}</color>");
                if(roll <= rarities[i].Weight){
                    return rarities[i]; //DEBUG ONLY
                }
                else{
                    roll -= rarities[i].Weight;
                }
            }
            Debug.LogError("COULD NOT FIND A RARITY");
            return null;
        }

    }
}
