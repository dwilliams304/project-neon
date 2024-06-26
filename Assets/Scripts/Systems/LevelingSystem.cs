using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    
    public delegate void OnLevelChange(int newLevel, int xpToNext, int newXpAmnt);
    public static OnLevelChange onLevelChange;

    public delegate void OnExperienceChange(int xpAmnt);
    public static OnExperienceChange onExperienceChange;

    [SerializeField] private AnimationCurve levelScaler;

    [SerializeField] private int currentLevel, currentExperience, experienceToNextLevel;
    
    [SerializeField] private bool capLevel;
    [SerializeField] private int levelCap;

    private void Start(){
        currentLevel = 1;
        currentExperience = 0;
    }


    public void AddExperience(int amnt){
        currentExperience += amnt;

        if(currentExperience >= experienceToNextLevel){
            LevelUp(currentExperience - experienceToNextLevel);
        }

        onExperienceChange?.Invoke(amnt);
    }


    private void LevelUp(int overflow){
        currentLevel++;
        experienceToNextLevel = (int)levelScaler.Evaluate(currentLevel);
        currentExperience = overflow;
        onLevelChange?.Invoke(currentLevel, experienceToNextLevel, overflow);
    }

}
