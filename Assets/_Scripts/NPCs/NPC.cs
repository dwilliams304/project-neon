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
        }

        private void OnDisable(){
            if(health != null) health.onDeath -= OnDeath;
        }


        private void Start(){
            if(npcBrain != null){
                npcBrain.Initialize(gameObject, npcData);
            }
            lootManager = LootManager.Instance;
            effectsManager = EffectsManager.Instance;
            gameManager = GameManager.Instance;
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