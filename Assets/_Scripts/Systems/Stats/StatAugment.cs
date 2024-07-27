/*
                THANK YOU TO KRYZAREL!!!
                
                TUTORIAL:
                https://www.youtube.com/watch?v=SH25f3cXBVc

*/


using System;

public enum StatAugmentType {
    Flat_Add = 100,
    Percent_Add = 200,
    Percent_Mult = 300,
}

[Serializable]
public class StatAugment {
    public readonly float Value;
    public readonly StatAugmentType AugmentType;
    public readonly int Order;
    public readonly object Source;

    public StatAugment(float value, StatAugmentType augmentType, int order, object source){
        Value = value;
        AugmentType = augmentType;
        Order = order;
        Source = source;
    }

    public StatAugment(float value, StatAugmentType augmentType) : this (value, augmentType, (int)augmentType) { }
    public StatAugment(float value, StatAugmentType augmentType, int order) : this (value, augmentType, order, null) { }
    public StatAugment(float value, StatAugmentType augmentType, object source) : this (value, augmentType, (int)augmentType, source) { }
}