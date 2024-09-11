using UnityEngine;


public class NPC : MonoBehaviour, IDamageable
{
    private Health health;


    [SerializeField] private NPCData npcData;
    [SerializeField] private NPCBrain npcBrain;


    private void Awake(){
        if(!npcData.IsFriendly && npcData.IsDamageable){
            health = GetComponent<Health>() ? GetComponent<Health>() : gameObject.AddComponent(typeof(Health)) as Health;
            health.InitializeHealthSystem(npcData.MaxHealth, npcData.IsDamageable, npcData.UsesHealthBar, npcData.ShowsDamageText, npcData.CanHeal);
        }
    }


    public void OnDamage(Stat damageStat = null)
    {
        if(!npcData.IsFriendly && npcData.IsDamageable){
            // bool crit = GameManager.Instance.CalculateIfCrit();
            health.TakeDamage(10);
        }
    }
}
