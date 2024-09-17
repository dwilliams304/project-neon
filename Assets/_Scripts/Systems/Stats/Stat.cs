/*
                THANK YOU TO KRYZAREL!!!
                
                TUTORIAL:
                https://www.youtube.com/watch?v=SH25f3cXBVc

*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ContradictiveGames
{
    [Serializable]
    public class Stat {
        public float BaseValue;
        public bool canNotAugment = false;

        public virtual float Value {
            get {
                if(isDirty || BaseValue != lastBaseValue){
                    lastBaseValue = BaseValue;
                    _value = CalculateValue();
                    isDirty = false;
                }
                return _value;
            }
        }


        
        protected bool isDirty = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;
        protected readonly List<StatAugment> _statAugments;
        public readonly ReadOnlyCollection<StatAugment> StatAugments;

        public Stat(){
            _statAugments = new List<StatAugment>();
            StatAugments = _statAugments.AsReadOnly();
        }

        public Stat(float _baseValue): this() {
            BaseValue = _baseValue;
        }




        public virtual void AddAugment(StatAugment augment){
            if(!canNotAugment){
                isDirty = true;
                _statAugments.Add(augment);
                _statAugments.Sort(CompareAugmentOrder);
            }
        }
        public virtual bool RemoveAugment(StatAugment augment){
            if(!canNotAugment){
                if(_statAugments.Remove(augment)){
                    isDirty = true;
                    return true;
                }
            }
            return false;
        }

        protected virtual int CompareAugmentOrder(StatAugment a, StatAugment b){
            if (a.Order < b. Order) return -1;
            else if (a.Order > b.Order) return 1;
            return 0;
        }

        public virtual bool RemoveAllAugmentsFromSource(object source){
            bool didRemove = false;
            if(!canNotAugment){
                for(int i = _statAugments.Count - 1; i >= 0; i--){
                    if(_statAugments[i].Source == source){
                        isDirty = true;
                        didRemove = true;
                        _statAugments.RemoveAt(i);
                    }
                }
            }
            return didRemove;
        }


        protected virtual float CalculateValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0; // This will hold the sum of our "PercentAdd" modifiers

            for (int i = 0; i < _statAugments.Count; i++)
            {
                StatAugment augment = _statAugments[i];

                if (augment.AugmentType == StatAugmentType.Flat_Add)
                {
                    finalValue += augment.Value;
                }
                else if (augment.AugmentType == StatAugmentType.Percent_Add) // When we encounter a "PercentAdd" modifier
                {
                    sumPercentAdd += augment.Value; // Start adding together all modifiers of this type

                    // If we're at the end of the list OR the next modifer isn't of this type
                    if (i + 1 >= _statAugments.Count || _statAugments[i + 1].AugmentType != StatAugmentType.Percent_Add)
                    {
                        finalValue *= 1 + sumPercentAdd; // Multiply the sum with the "finalValue", like we do for "PercentMult" modifiers
                        sumPercentAdd = 0; // Reset the sum back to 0
                    }
                }
                else if (augment.AugmentType == StatAugmentType.Percent_Mult) // Percent renamed to PercentMult
                {
                    finalValue *= 1 + augment.Value;
                }
            }

            return (float)Math.Round(finalValue, 4);
        }
    }
}