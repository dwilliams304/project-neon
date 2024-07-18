using UnityEngine;
using TMPro;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text text;

    void Start(){
        if(text == null){
            text = GetComponent<TMP_Text>();
        }
        if(player == null){
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        text.text = player.position.ToString();
    }
}
