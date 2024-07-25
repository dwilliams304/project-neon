using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUDUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider xpBar;
    [SerializeField] private TMP_Text levelText;

    private void OnEnable(){
        XPManager.onExperienceChange += UpdateXPBar;
        XPManager.onLevelChange += UpdateLevel;
    }

    private void OnDisable(){
        XPManager.onExperienceChange -= UpdateXPBar;
        XPManager.onLevelChange -= UpdateLevel;
    }

    private void UpdateXPBar(int amountToAdd){
        xpBar.value += amountToAdd;
    }

    private void UpdateLevel(int newLevel, int xpToNext, int newXpAmnt){
        xpBar.maxValue = xpToNext;
        xpBar.value = newXpAmnt;
        levelText.text = $"Lvl. {newLevel}";
    }

}
