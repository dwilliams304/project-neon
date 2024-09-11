using UnityEngine;


public class NPC : MonoBehaviour
{
    private Health health;


    [SerializeField] private NPCData npcData;
    [SerializeField] private NPCBrain npcBrain;


    private void Awake(){
        if(!npcData.IsFriendly && npcData.IsDamageable){
            health = GetComponent<Health>() ? GetComponent<Health>() : gameObject.AddComponent(typeof(Health)) as Health;
            health.InitializeHealthSystem(npcData.MaxHealth, npcData.UsesHealthBar, npcData.ShowsDamageText, npcData.CanHeal);
        }
    }


}
