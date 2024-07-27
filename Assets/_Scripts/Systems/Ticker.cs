using UnityEngine;

public class Ticker : MonoBehaviour
{
    public static Ticker Instance;

    [SerializeField] private float tickTimer;
    private float lastTick;

    public delegate void OnNormalTick();
    public static OnNormalTick onNormalTick;

    public delegate void OnSecondTick();
    public OnSecondTick onSecondTick;

    public delegate void OnFifthTick();
    public static OnFifthTick onFifthTick;

    private int tick;

    private void Awake(){
        Instance = this;
        tick = 0;
    }
    
    private void Update(){
        if(Time.time >= lastTick + tickTimer){
            onNormalTick?.Invoke();
            tick++;
            if(tick % 2 == 0){
                onSecondTick?.Invoke();
            }
            if(tick % 5 == 0){
                onFifthTick?.Invoke();
            }
            lastTick = Time.time;
        }
    }
}
