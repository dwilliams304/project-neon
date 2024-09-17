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
namespace ContradictiveGames.Player
{
    public class PlayerStats : MonoBehaviour
    {
        [Header("Health Stats")]
        [Space]
        public Stat HealthRegenAmount;
        public Stat HealthRegenSpeed;
        public Stat DamageTaken;
        [Space(15)]

        [Header("Damage Stats")]
        [Space]
        public Stat BaseDamage;
        public Stat CritChance;
        public Stat CritDamageMultiplier;
        [Space(15)]

        [Header("Combat Stats")]
        [Space]
        public Stat FireRate;
        public Stat ReloadSpeed;
        public Stat ProjectileSpeed;
        [Space(15)]

        [Header("Movement Stats")]
        [Space]
        public Stat MoveSpeed;
        public Stat DashSpeed;
        public Stat DashCooldown;
        public Stat DashDuration;
        [Space(15)]

        [Header("Corruption Stats")]
        [Space]
        public Stat CorruptionGainAmount;
        public Stat CorruptionGainSpeed;
        [Space(15)]

        [Header("Misc. Stats")]
        [Space]
        public Stat LuckStat;
        public Stat ExperienceMultiplier;
        public Stat CurrencyMultiplier;
    }
}