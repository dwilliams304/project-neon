using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;





    /*  -----------------------------------------------------------------
        |                       PLACEHOLDER!!!!!                        |
        |  Will change in the future, dirty way of showing percentages. |
        |                   TODO: MAKE THIS NICER!!!                    |
        -----------------------------------------------------------------
    */




namespace ContradictiveGames.UI
{
    public class SliderValuesToText : MonoBehaviour
    {
        private Slider slider;
        private TMP_Text text;



        void Awake(){
            slider = GetComponentInParent<Slider>();
            text = GetComponent<TMP_Text>();
            slider.onValueChanged.AddListener(delegate{
                if(PlayerHUDUI.showPercentages == true && PlayerHUDUI.showTotalValues == true){
                    ChangeValuesText_Both();
                }
                else if(PlayerHUDUI.showPercentages == true && PlayerHUDUI.showTotalValues == false){
                    ChangeValuesText_Pct_Only();
                }
                else if(PlayerHUDUI.showPercentages == false && PlayerHUDUI.showTotalValues == true){
                    ChangeValuesText_Vals_Only();
                }
                else Destroy(this);
            });
        }


        void Start(){
            if(PlayerHUDUI.showPercentages == true && PlayerHUDUI.showTotalValues == true){
                ChangeValuesText_Both();
            }
            else if(PlayerHUDUI.showPercentages == true && PlayerHUDUI.showTotalValues == false){
                ChangeValuesText_Pct_Only();
            }
            else if(PlayerHUDUI.showPercentages == false && PlayerHUDUI.showTotalValues == true){
                ChangeValuesText_Vals_Only();
            }
        }

        void ChangeValuesText_Pct_Only(){
            text.text = (slider.value / slider.maxValue * 100f).ToString() + "%";
        }

        void ChangeValuesText_Vals_Only(){
            text.text = slider.value.ToString() + " / " + slider.maxValue.ToString();
        }

        void ChangeValuesText_Both(){
            text.text = slider.value.ToString() + " / " + slider.maxValue.ToString()
                +
            " (" + Math.Round(slider.value / slider.maxValue * 100f, 2).ToString() + "%)";
        }
    }
}