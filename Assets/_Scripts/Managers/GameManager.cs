using UnityEngine;
using ContradictiveGames.Player;

namespace ContradictiveGames.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;


        [Header("References")]
        [SerializeField] private GameObject player;
        private PlayerStats playerStats;


        [Header("Difficulty Settings")]
        [SerializeField] private AnimationCurve enemyHealthScaler;
        [SerializeField] private AnimationCurve enemyDamageScaler;
        [Space]
        
        [Header("Enemy Drop Settings")]
        [SerializeField] private AnimationCurve enemyXPDropScaler;
        [SerializeField] private AnimationCurve enemyCurrencyDropScaler;
        [Space]
        
        [Header("Cost Requirements")]
        [SerializeField] private AnimationCurve itemCostScaler;
        [Space]


        //FLOATS
        public float enemyHealthScale;
        public float enemyDamageScale;
        public float enemyXPDropScale;
        public float enemyCurrencyDropScale;
        public float itemCostScale;

        [Header("Other Variables")]
        [SerializeField] private float damageVariance;


        private void OnEnable(){
            XPManager.onLevelChange += HandleLevelChange;
        }
        private void OnDisable(){
            XPManager.onLevelChange -= HandleLevelChange;
        }


        void Awake() => Instance = this;

        void Start(){
            if(player == null){
                player = GameObject.FindGameObjectWithTag("Player");
            }
            playerStats = player.GetComponent<PlayerStats>();
            HandleLevelChange(0);
        }

        public bool CalculateIfCrit(){
            if(Random.Range(0, 101) <= playerStats.CritChance.Value) return true;
            return false;
        }

        public int CalculatePlayerDamageDone(bool wasCrit){
            float finalDamage;
            float variance = Random.Range(-damageVariance, damageVariance);
            finalDamage = playerStats.BaseDamage.Value + variance;
            if(wasCrit){
                finalDamage *= playerStats.CritDamageMultiplier.Value;
            }
            return Mathf.CeilToInt(finalDamage);
        }

        public float CalculateDamage(Stat damageStat){
            float variance = Random.Range(-damageVariance, damageVariance);
            if(damageStat == null) return 10 + variance;
            return damageStat.Value + variance;
        }


        private void HandleLevelChange(int newLevel, int a = 0, int b = 0){
            enemyHealthScale = enemyHealthScaler.Evaluate(newLevel);
            enemyDamageScale = enemyDamageScaler.Evaluate(newLevel);
            enemyXPDropScale = enemyXPDropScaler.Evaluate(newLevel);
            enemyCurrencyDropScale = enemyCurrencyDropScaler.Evaluate(newLevel);
            itemCostScale = itemCostScaler.Evaluate(newLevel);
        }


    }
}