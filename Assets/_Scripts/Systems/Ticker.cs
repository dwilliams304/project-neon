using UnityEngine;

public class Ticker : MonoBehaviour
{
    public static Ticker Instance;

    [SerializeField] private float tickTimer;
    private float lastTick;

    public delegate void OnTick();
    public OnTick onTick;

    private void Awake(){
        Instance = this;
    }
    
    private void Update(){
        if(Time.time >= lastTick + tickTimer){
            onTick?.Invoke();
            lastTick = Time.time;
        }
    }
}
