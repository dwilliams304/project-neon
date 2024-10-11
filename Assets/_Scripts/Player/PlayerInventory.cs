using UnityEngine;

namespace ContradictiveGames.Player
{
    [RequireComponent(typeof(PlayerStats))]
    public class PlayerInventory : MonoBehaviour
    {
        //Gold, Augments, Consumables, all that stuff!

        private PlayerStats playerStats;

        public static PlayerInventory Instance;

        public delegate void OnCurrencyChange(int amount);
        public static OnCurrencyChange onCurrencyChange;




        [SerializeField] private int currency;


        private void Awake() {
            Instance = this;
            currency = 0;
        }

        private void Start(){
            playerStats = GetComponent<PlayerStats>();
        }



        public void AddCurrency(int amount){
            currency += Mathf.RoundToInt(amount * playerStats.CurrencyMultiplier.Value);
            onCurrencyChange?.Invoke(currency);
        }



    }
}