using System.Collections.Generic;
using UnityEngine;


    // Health,
    // Health_Regen_Amount,
    // Health_Regen_Speed,
    // Damage,
    // Damage_Taken_Multiplier,
    // Crit_Chance,
    // Crit_Damage_Multiplier,
    // FireRate,
    // ProjectileSpeed,
    // ReloadSpeed,
    // Move_Speed,
    // DashSpeed,
    // DashCooldown,
    // XP_Multiplier,
    // Currency_Multiplier,
    // Corruption_Ticker,
    // Corruption_Gain_Multiplier,
namespace ContradictiveGames
{
    [CreateAssetMenu(fileName = "CharacterAugment", menuName = "Custom/Augments", order = 0)]
    public class CharacterAugment : ScriptableObject
    {
        public string augmentName;
        [Multiline]
        public string augmentDescription;

        public List<StatAugment> augments;

        public void AddAugment(GameObject playerObject){
            //AddAugment(this)
            for(int i = 0; i < augments.Count; i++){
                var cur = augments[i];
                switch(cur.statToAugment){
                    case StatToAugment.Health:
                    break;

                    default:
                    break;
                }
            }
        }

        public void RemoveAllAugments(){
            //RemoveAllModifiersFromSource(this);
            for(int i = 0; i < augments.Count; i++){
                var cur = augments[i];
                switch(cur.statToAugment){
                    case StatToAugment.Health:
                    break;

                    default:
                    break;
                }
            }
        }

    }
}