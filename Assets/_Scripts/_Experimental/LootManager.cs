using System.Collections.Generic;
using UnityEngine;

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
            totalWeights += rarities[i].PercentDropChance;
        }

// #if UNITY_EDITOR
//         rarities.Sort(delegate(Rarity a, Rarity b){
//             return a.PercentDropChance.CompareTo(b.PercentDropChance);
//         });
// #endif

    }


    public void DropLoot(Vector3 DropPos){
        int roll = Random.Range(0, totalWeights + 1);
        roll /= 1 + (int)luckStat.Value;

        for(int i = rarities.Count; i >= 0; i--){
            if(roll <= rarities[i].PercentDropChance){
                GameObject lootDrop = rarities[i].LootTable.RandomFromList();
                Instantiate(lootDrop, DropPos, Quaternion.identity);
                break;
            }
        }
    }


    public void SortRarites(){
        rarities.Sort(delegate(Rarity a, Rarity b){
            return a.PercentDropChance.CompareTo(b.PercentDropChance);
        });
    }

}
