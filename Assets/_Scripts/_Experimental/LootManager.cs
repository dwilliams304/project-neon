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
            totalWeights += rarities[i].Weight;
        }
    }


    // private void Update(){
    //     if(Input.GetKeyDown(KeyCode.G)){
    //         DropLoot(Vector3.zero);
    //     }
    // }


    public void DropLoot(Vector3 DropPos){
        int roll = Random.Range(0, totalWeights + 1);
        int starterRoll = roll; //DEBUG ONLY
        roll /= 1 + (int)luckStat.Value;

        string rarityChosen = ""; //DEBUG ONLY

        for(int i = 0; i <= rarities.Count; i++){
            if(roll <= rarities[i].Weight){
                // GameObject lootDrop = rarities[i].LootTable.RandomFromList();
                // Instantiate(lootDrop, DropPos, Quaternion.identity);
                rarityChosen = rarities[i].RarityName; //DEBUG ONLY
                break;
            }
            else{
                roll -= rarities[i].Weight;
            }
        }

        Debug.Log($"Rolled a {starterRoll}, and got a {rarityChosen} drop!"); //DEBUG ONLY
    }


    public void SortRarites(){
        rarities.Sort(delegate(Rarity a, Rarity b){
            return a.Weight.CompareTo(b.Weight);
        });
    }

}
