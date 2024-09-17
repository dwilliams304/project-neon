/*
                THANK YOU TO KRYZAREL!!!
                
                TUTORIAL:
                https://www.youtube.com/watch?v=SH25f3cXBVc

*/


using System;

namespace ContradictiveGames
{
    public enum StatAugmentType {
        Flat_Add = 100,
        Percent_Add = 200,
        Percent_Mult = 300,
    }

    public enum StatToAugment {
        Health,
        Health_Regen_Amount,
        Health_Regen_Speed,
        Damage,
        Damage_Taken_Multiplier,
        Crit_Chance,
        Crit_Damage_Multiplier,
        FireRate,
        ProjectileSpeed,
        ReloadSpeed,
        Move_Speed,
        DashSpeed,
        DashCooldown,
        XP_Multiplier,
        Currency_Multiplier,
        Corruption_Ticker,
        Corruption_Gain_Multiplier,
    }

    [Serializable]
    public class StatAugment {
        public float Value;
        public StatAugmentType AugmentType;
        public StatToAugment statToAugment;
        public readonly int Order;
        public readonly object Source;

        public StatAugment(float value, StatAugmentType augmentType, int order, object source){
            Value = value;
            AugmentType = augmentType;
            Order = order;
            Source = source;
        }

        public StatAugment(float value, StatAugmentType augmentType) : this (value, augmentType, (int)augmentType) { }
        public StatAugment(float value, StatAugmentType augmentType, int order) : this (value, augmentType, order, null) { }
        public StatAugment(float value, StatAugmentType augmentType, object source) : this (value, augmentType, (int)augmentType, source) { }
    }
}