using System.Collections.Generic;
using UnityEngine;

public class Experimental_LootManager : MonoBehaviour
{
    [System.Serializable]
    public class Rarity {
        [Header("Rarity Details")]
        public string RarityName = "Default Name";
        public Color RarityColor = Color.white;
        public float ChanceToDrop = 100;
    }

    public List<Rarity> rarities = new List<Rarity>();


    private void Start(){
        if(rarities.Count == 0){
            Debug.LogError("No rarities setup. Please fix this.");
        }
        rarities.Sort(delegate(Rarity a, Rarity b){
            return a.ChanceToDrop.CompareTo(b.ChanceToDrop);
        });

        // Debug.Log(rarities);
        // foreach(Rarity r in rarities){
        //     Debug.Log($"{r.RarityName} - chance to drop: {r.ChanceToDrop}%");
        // }
    }

    private void RollForLoot(int RollTo = 1000){
        int rolled = Random.Range(0, RollTo + 1);
        for(int i = 0; i < rarities.Count; i++){
            var cur = rarities[i];
            if(rolled <= RollTo * (cur.ChanceToDrop / 100)){ //is this even needed? why not just roll 1 - 100?
                // Debug.Log($"I rolled a {rolled}, and got a {cur.RarityName} drop!");
                break;
            }
        }
    }
}
