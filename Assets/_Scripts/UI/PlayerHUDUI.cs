using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ContradictiveGames.Managers;
using ContradictiveGames.Player;


namespace ContradictiveGames.UI
{
    public class PlayerHUDUI : MonoBehaviour
    {

        public static PlayerHUDUI Instance;

        [Header("UI Elements")]
        [SerializeField] private Slider xpBar;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text currencyText;

        [SerializeField] private TMP_Text ammoText;


        //CHANGE THESE TO BE A SETTING - NOT SOMETHING SET HERE!
        public static bool showPercentages = true;
        public static bool showTotalValues = true;


        private void OnEnable(){
            XPManager.onExperienceChange += UpdateXPBar;
            XPManager.onLevelChange += UpdateLevel;
            PlayerInventory.onCurrencyChange += UpdateGoldAmount;
        }

        private void OnDisable(){
            XPManager.onExperienceChange -= UpdateXPBar;
            XPManager.onLevelChange -= UpdateLevel;
            PlayerInventory.onCurrencyChange -= UpdateGoldAmount;
        }

        private void Awake(){
            Instance = this;
        }

        private void UpdateXPBar(int newValue){
            xpBar.value = newValue;
        }

        private void UpdateGoldAmount(int newAmount){
            currencyText.text = newAmount.ToString() + " b";
        }

        private void UpdateLevel(int newLevel, int xpToNext, int newXpAmnt){
            xpBar.maxValue = xpToNext;
            xpBar.value = newXpAmnt;
            levelText.text = $"Lvl. {newLevel}";
        }

        public void UpdateAmmoText(int cur, int max){
            ammoText.text = $"{cur} / {max}";
        }
        


    }
}