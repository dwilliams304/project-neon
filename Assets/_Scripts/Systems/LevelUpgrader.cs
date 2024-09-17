using UnityEngine;
using ContradictiveGames.Managers;
using ContradictiveGames.Player;


namespace ContradictiveGames
{
    public class LevelUpgrader : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private GameObject levelUpPanel;


        [Header("Other References")]
        [SerializeField] private GameObject player;


        [Header("Default Upgrade Amounts")]
        [SerializeField] private int maxHealthToAdd;
        [SerializeField] private int damageToAdd;


        //PRIVATE VARS
        private PlayerStats playerStats;
        private Health playerHealth;


        private void OnEnable(){
            XPManager.onLevelChange += HandleLevelChange;
        }

        private void OnDisable(){
            XPManager.onLevelChange -= HandleLevelChange;
        }


        private void Start(){
            if(player == null){
                Debug.Log("Player reference not set, setting now!");
                player = GameObject.FindGameObjectWithTag("Player");
            }
            playerStats = player.GetComponent<PlayerStats>();
            playerHealth = player.GetComponent<Health>();
        }


        private void HandleLevelChange(int newLevel, int xpToNext, int newXpAmnt){
            playerStats.BaseDamage.AddAugment(new StatAugment(damageToAdd, StatAugmentType.Flat_Add, this));
            // playerHealth.IncreaseMaxHealth(maxHealthToAdd, this, true);
            UIManager.Instance.TogglePanel(levelUpPanel);
        }

        public void UpgradeSelected(){
            UIManager.Instance.TogglePanel(levelUpPanel);
        }

    }
}