using System.Collections.Generic;
using UnityEngine;
using ContradictiveGames.Loot;
using ContradictiveGames.Player;
using Unity.VisualScripting;

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
            int roll = Random.Range(0, totalWeights + 1);
            // roll /= 1 + (int)luckStat.Value;
            Rarity _rarity = ChooseRarity(roll);

            string colorHex = _rarity.RarityColor.ToHexString(); //DEBUG ONLY
            Debug.Log($"Rolled and got a(n) <color=#{colorHex}><b> {_rarity.RarityName} </b></color> drop!"); //DEBUG ONLY
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
                if(roll <= rarities[i].Weight){
                    return rarities[i]; //DEBUG ONLY
                }
                else{
                    roll -= rarities[i].Weight;
                }
            }
            return null;
        }

    }
}
