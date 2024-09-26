using UnityEngine;

namespace ContradictiveGames.AI
{
    public abstract class NPCBrain : ScriptableObject {
        
        protected NPCData npcData;
        protected GameObject npcGameObject;
        protected Transform npcTransform;
        public Transform targetTransform;
        

        /// <summary>
        /// Set up the NPC Brain's main variables
        /// </summary>
        /// <param name="_gameObject"></param>
        /// <param name="_npcData"></param>
        /// <param name="_mainTarget"></param>
        public virtual void Initialize(GameObject _gameObject, NPCData _npcData){
            npcGameObject = _gameObject;
            npcTransform = _gameObject.transform;
            npcData = _npcData;
            
            //Allows for more flexibility, if it is going to be a healer or not
            if(_npcData.PlayerIsTarget) targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
            
        }

        /// <summary>
        /// What needs to be true for the main logic to happen (i.e: if in range of main target, do something)
        /// </summary>
        /// <returns></returns>
        public virtual bool CheckConditions(){
            return false;
        }


        /// <summary>
        /// What you want the NPC to do any time there is a frame update
        /// </summary>
        public virtual void DoUpdateLogic(){
            //For things that would need to happen every frame (i.e: movement)
        }

        /// <summary>
        /// What you want the NPC to do any time there is a tick
        /// </summary>
        public virtual void DoTickLogic(){
            //For more expensive calls, so it is not done every frame (i.e: recalculating position to move to)
        }


        /// <summary>
        /// If the check conditions return true, do this
        /// </summary>
        public virtual void DoMainLogic(){
            //What the NPC will do if their main conditions are met (i.e: attack if in range of target)
        }
    }
}