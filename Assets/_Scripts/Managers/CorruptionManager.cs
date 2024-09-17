using UnityEngine;

namespace ContradictiveGames.Managers
{
    public enum CorruptionTier {
        Tier1,
        Tier2,
        Tier3,
        Tier4,
        Tier5,
        Tier6
    }

    public class CorruptionManager : MonoBehaviour
    {
        public static CorruptionManager Instance;

        public Stat CorruptionTickAmount;
        public Stat CorruptionTickSpeed;


        [SerializeField] private int currentCorruptionAmount;
        [SerializeField] private int corruptionToNextTier;

        [SerializeField] private AnimationCurve corruptionScaler;

        [SerializeField] private CorruptionTier corruptionTier;


        public delegate void OnCorruptionAmountChange(int amount);
        public OnCorruptionAmountChange onCorruptionAmountChange;

        public delegate void OnCorruptionTierChange(CorruptionTier tier);
        public OnCorruptionTierChange onCorruptionTierChange;



        private void Awake(){
            Instance = this;
        }


        private void Start(){
            currentCorruptionAmount = 0;

        }


        public void AddCorruption(int amount){
            currentCorruptionAmount += amount;
            if(currentCorruptionAmount >= corruptionToNextTier){
                int overflow = currentCorruptionAmount - corruptionToNextTier;
                ChangeCorruptionTier(corruptionTier, overflow);
            }
            onCorruptionAmountChange?.Invoke(currentCorruptionAmount);
        }



        private void ChangeCorruptionTier(CorruptionTier currentTier, int newCorruptionAmount){
            
        }
    }
}