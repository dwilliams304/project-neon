using UnityEngine;

namespace ContradictiveGames.AI
{
    [CreateAssetMenu(fileName = "Chaser", menuName = "NPCs/Brains/Chaser Brain")]
    public class NPCChaserBrain : NPCBrain
    {
        public override bool CheckConditions()
        {
            return true;
        }

        public override void DoUpdateLogic()
        {
            base.DoUpdateLogic();
        }

        public override void DoTickLogic()
        {
            Debug.Log($"I am doing something on a tick! (I should be chasing)");
        }

        public override void DoMainLogic()
        {
            base.DoMainLogic();
        }
    }
}
