using UnityEngine;

namespace ContradictiveGames
{
    public class XPManager : MonoBehaviour
    {
        public static XPManager Instance;

        public delegate void OnLevelChange(int newLevel, int xpToNext, int newXpAmnt);
        public static OnLevelChange onLevelChange;

        public delegate void OnExperienceChange(int xpAmnt);
        public static OnExperienceChange onExperienceChange;


        [SerializeField] private AnimationCurve levelScaler;
        [SerializeField] private bool capLevel;
        [SerializeField] private int levelCap;
        public Stat XP_Multiplier;

        private int currentLevel, currentExperience, experienceToNextLevel;


        private void Awake() => Instance = this;

        private void Start(){
            currentLevel = 1;
            currentExperience = 0;
            experienceToNextLevel = (int)levelScaler.Evaluate(currentLevel);
        }


        public void AddExperience(int amnt){
            currentExperience += Mathf.CeilToInt(amnt * XP_Multiplier.Value);
            if(currentExperience >= experienceToNextLevel) LevelUp(currentExperience - experienceToNextLevel);
            else onExperienceChange?.Invoke(currentExperience);
        }


        private void LevelUp(int overflow){
            currentLevel++;
            experienceToNextLevel = (int)levelScaler.Evaluate(currentLevel);
            currentExperience = overflow;
            onLevelChange?.Invoke(currentLevel, experienceToNextLevel, overflow);
        }


        // public void IncreaseXPMultiplier(float amount, object source){
        //     XP_Multiplier.AddAugment(new StatAugment(amount, StatAugmentType.Percent_Add, source));
        // }

    }
}