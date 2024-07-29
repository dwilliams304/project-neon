using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //Gold, Augments, Consumables, all that stuff!
    public Stat CurrencyMultiplier;

    public static PlayerInventory Instance;

    public delegate void OnCurrencyChange(int amount);
    public static OnCurrencyChange onCurrencyChange;


    [SerializeField] private int currency;


    private void Awake() {
        Instance = this;
        currency = 0;
    }



    public void AddGold(int amount){
        currency += Mathf.RoundToInt(amount * CurrencyMultiplier.Value);
        onCurrencyChange?.Invoke(currency);
    }
}
