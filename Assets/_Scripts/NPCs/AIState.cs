using UnityEngine;

public abstract class AIState : ScriptableObject {

    public virtual void StateEnter(NPC npc){

    }
    
    public virtual void StateActive(NPC npc){

    }
    
    public virtual void StateExit(NPC npc){

    }
}