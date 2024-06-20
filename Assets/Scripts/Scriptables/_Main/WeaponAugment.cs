using  UnityEngine;

public enum WeaponAugmentType {
    Augment_Type_1,
    Augment_Type_2,
    Augment_Type_3,
    Augment_Type_4
}

public abstract class WeaponAugment : ScriptableObject {
    public string WeaponName = "Default Weapon";
    public int MinimumDamage = 1;
    public int MaximumDamage = 2;
    public int CriticalStrikeChance = 1;



    public Sprite WeaponIcon;


    public WeaponAugmentType weaponAugmentType = WeaponAugmentType.Augment_Type_1;
    // public Rarity rarity = Rarity.Common;

    
}