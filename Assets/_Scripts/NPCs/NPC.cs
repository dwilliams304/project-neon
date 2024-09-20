using UnityEngine;
using ContradictiveGames.Managers;
using ContradictiveGames.Player;
using ContradictiveGames.Utility;

namespace ContradictiveGames.AI
{
    public class NPC : MonoBehaviour, IDamageable
    {
        private Health health;


        [SerializeField] private NPCData npcData;
        [SerializeField] private NPCBrain npcBrain;

        private GameObject playerTarget;
        private LootManager lootManager;
        private EffectsManager effectsManager;


        private void Awake(){
            if(npcData.IsDamageable){
                health = GetComponent<Health>() ? GetComponent<Health>() : gameObject.AddComponent(typeof(Health)) as Health;
                health.InitializeHealthSystem(npcData);
            }
        }
        
        private void OnEnable(){
            if(health != null) health.onDeath += OnDeath;
            if(!npcData.IsStaticNpc){
                switch(npcData.thinkingSpeed){
                    case ThinkingSpeed.None:
                        break;

                    case ThinkingSpeed.Short:
                        Ticker.onShortTick += OnTick;
                        break;
                    
                    case ThinkingSpeed.Normal:
                        Ticker.onNormalTick += OnTick;
                        break;

                    case ThinkingSpeed.Second:
                        Ticker.onSecondTick += OnTick;
                        break;

                    case ThinkingSpeed.Fifth:
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

                    case ThinkingSpeed.Short:
                        Ticker.onShortTick -= OnTick;
                        break;
                    
                    case ThinkingSpeed.Normal:
                        Ticker.onNormalTick -= OnTick;
                        break;

                    case ThinkingSpeed.Second:
                        Ticker.onSecondTick -= OnTick;
                        break;

                    case ThinkingSpeed.Fifth:
                        Ticker.onFifthTick -= OnTick;
                        break;
                }
            }
        }


        private void Start(){
            playerTarget = GameObject.FindGameObjectWithTag("Player");
            lootManager = LootManager.Instance;
            effectsManager = EffectsManager.Instance;
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
                // bool crit = GameManager.Instance.CalculateIfCrit();
                health.TakeDamage(10);
            }
        }


        private void OnDeath(){
            gameObject.SetActive(false);
            effectsManager.CallForXPParticles(transform.position, npcData.XPDrop);
            effectsManager.CallForGoldParticles(transform.position, npcData.CurrencyDrop);
            lootManager.DropLoot(transform.position);
            // playerInventory.AddCurrency(npcData.CurrencyDrop);
        }
    }
}