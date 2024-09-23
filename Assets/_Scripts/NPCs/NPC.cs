using UnityEngine;
using ContradictiveGames.Managers;
using ContradictiveGames.Utility;

namespace ContradictiveGames.AI
{
    public class NPC : MonoBehaviour, IDamageable
    {
        private Health health;


        [SerializeField] private NPCData npcData;
        [SerializeField] private NPCBrain npcBrain;

        private GameObject playerTarget;
        private GameManager gameManager;
        private LootManager lootManager;
        private EffectsManager effectsManager;
        private DamageFlasher damageFlasher;




        private void Awake(){
            if(npcData.IsDamageable){
                health = GetComponent<Health>() ? GetComponent<Health>() : gameObject.AddComponent(typeof(Health)) as Health;
                health.InitializeHealthSystem(npcData);
                damageFlasher = GetComponent<DamageFlasher>() ? GetComponent<DamageFlasher>() : gameObject.AddComponent(typeof(DamageFlasher)) as DamageFlasher;
            }
        }
        
        private void OnEnable(){
            if(health != null) health.onDeath += OnDeath;
            
            if(!npcData.IsStaticNpc){
                switch(npcData.thinkingSpeed){
                    case ThinkingSpeed.None:
                        break;

                    case ThinkingSpeed.Fast:
                        Ticker.onShortTick += OnTick;
                        break;
                    
                    case ThinkingSpeed.Normal:
                        Ticker.onNormalTick += OnTick;
                        break;

                    case ThinkingSpeed.Slow:
                        Ticker.onSecondTick += OnTick;
                        break;

                    case ThinkingSpeed.Slowest:
                        Ticker.onFifthTick += OnTick;
                        break;
                }
            }

        }

        private void OnDisable(){
            if(health != null) health.onDeath -= OnDeath;
            if(!npcData.IsStaticNpc){
                switch(npcData.thinkingSpeed){
                    case ThinkingSpeed.None:
                        break;

                    case ThinkingSpeed.Fast:
                        Ticker.onShortTick -= OnTick;
                        break;
                    
                    case ThinkingSpeed.Normal:
                        Ticker.onNormalTick -= OnTick;
                        break;

                    case ThinkingSpeed.Slow:
                        Ticker.onSecondTick -= OnTick;
                        break;

                    case ThinkingSpeed.Slowest:
                        Ticker.onFifthTick -= OnTick;
                        break;
                }
            }
        }


        private void Start(){
            playerTarget = GameObject.FindGameObjectWithTag("Player");
            lootManager = LootManager.Instance;
            effectsManager = EffectsManager.Instance;
            gameManager = GameManager.Instance;
        }


        private void Update(){
            if(!npcData.IsStaticNpc){
                if(npcBrain.CheckConditions()) npcBrain.DoMainLogic();
                npcBrain.DoUpdateLogic();
            }
        }

        private void OnTick(){
            npcBrain.DoTickLogic();
        }




        public void OnDamage(Stat damageStat = null)
        {
            if(!npcData.IsFriendly && npcData.IsDamageable){
                bool crit = gameManager.CalculateIfCrit();
                int damage = gameManager.CalculatePlayerDamageDone(crit);
                health.TakeDamage(damage, crit);
                damageFlasher.DoDamageFlash(crit);
            }
        }


        private void OnDeath(){
            gameObject.SetActive(false);
            effectsManager.DropXPParticles(transform.position, npcData.XPDrop);
            effectsManager.DropCurrencyParticles(transform.position, npcData.CurrencyDrop);
            lootManager.DropLoot(transform.position);
        }
    }
}