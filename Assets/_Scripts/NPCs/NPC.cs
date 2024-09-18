using UnityEngine;
using ContradictiveGames.Managers;
using ContradictiveGames.Player;
using ContradictiveGames.Loot;

namespace ContradictiveGames.AI
{
    public class NPC : MonoBehaviour, IDamageable
    {
        private Health health;


        [SerializeField] private NPCData npcData;
        [SerializeField] private NPCBrain npcBrain;

        private GameObject playerTarget;
        private PlayerInventory playerInventory;
        private bool isDead;
        


        private void Awake(){
            isDead = false;
            if(npcData.IsDamageable){
                health = GetComponent<Health>() ? GetComponent<Health>() : gameObject.AddComponent(typeof(Health)) as Health;
                health.InitializeHealthSystem(npcData);
            }
        }
        
        private void OnEnable(){
            if(health != null) health.onDeath += OnDeath;
        }
        private void OnDisable(){
            if(health != null) health.onDeath -= OnDeath;
        }

        private void Start(){
            playerTarget = GameObject.FindGameObjectWithTag("Player");
            playerInventory = playerTarget.GetComponent<PlayerInventory>();
        }



        public void OnDamage(Stat damageStat = null)
        {
            if(!npcData.IsFriendly && npcData.IsDamageable){
                // bool crit = GameManager.Instance.CalculateIfCrit();
                health.TakeDamage(10);
            }
        }


        private void OnDeath(){
            //isDead = true;
            gameObject.SetActive(false);
            EffectsManager.Instance.CallForXPParticles(transform.position, npcData.XPDrop);
            playerInventory.AddCurrency(npcData.CurrencyDrop);
            // XPManager.Instance.AddExperience(npcData.XPDrop);
            LootManager.Instance.DropLoot(transform.position);
        }
    }
}