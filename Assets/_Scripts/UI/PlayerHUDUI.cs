using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUDUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider xpBar;
    [SerializeField] private TMP_Text levelText;


    //CHANGE THESE TO BE A SETTING - NOT SOMETHING SET HERE!
    public static bool showPercentages = true;
    public static bool showTotalValues = true;


    private void OnEnable(){
        XPManager.onExperienceChange += UpdateXPBar;
        XPManager.onLevelChange += UpdateLevel;
    }

    private void OnDisable(){
        XPManager.onExperienceChange -= UpdateXPBar;
        XPManager.onLevelChange -= UpdateLevel;
    }

    private void UpdateXPBar(int newValue){
        xpBar.value = newValue;
    }

    private void UpdateLevel(int newLevel, int xpToNext, int newXpAmnt){
        xpBar.maxValue = xpToNext;
        xpBar.value = newXpAmnt;
        levelText.text = $"Lvl. {newLevel}";
    }

}
