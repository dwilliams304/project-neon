using UnityEngine;
using TMPro;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text text;

    void OnEnable() => Ticker.onSecondTick += UpdatePositionText; 
    void OnDisable() => Ticker.onSecondTick -= UpdatePositionText; 


    void UpdatePositionText(){
        text.text = player.position.ToString();
    }

    void Start(){
        if(text == null){
            text = GetComponent<TMP_Text>();
        }
        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
}
