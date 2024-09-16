using System;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class PlayerInventory : MonoBehaviour
{
    //Gold, Augments, Consumables, all that stuff!

    private PlayerStats playerStats;

    public static PlayerInventory Instance;

    public delegate void OnCurrencyChange(int amount);
    public static OnCurrencyChange onCurrencyChange;


    public CharacterAugment Augment1;
    public CharacterAugment Augment2;
    public CharacterAugment Augment3;
    public CharacterAugment Augment4;
    public CharacterAugment Augment5;


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


    public void ModifyCurrentAugments(CharacterAugment newAugment, int augmentToSwap){
        switch(augmentToSwap){
            case 1:
                if(Augment1 != null) Augment1.RemoveAllAugments();
                Augment1 = newAugment;
                newAugment.AddAugment(gameObject);
                break;
            case 2:
                if(Augment2 != null) Augment2.RemoveAllAugments();
                Augment2 = newAugment;
                newAugment.AddAugment(gameObject);
                break;
            case 3:
                if(Augment3 != null) Augment3.RemoveAllAugments();
                Augment3 = newAugment;
                newAugment.AddAugment(gameObject);
                break;
            case 4:
                if(Augment4 != null) Augment4.RemoveAllAugments();
                Augment4 = newAugment;
                newAugment.AddAugment(gameObject);
                break;
            case 5:
                if(Augment5 != null) Augment5.RemoveAllAugments();
                Augment5 = newAugment;
                newAugment.AddAugment(gameObject);
                break;
        }
    }

}
