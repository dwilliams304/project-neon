using UnityEngine;


namespace ContradictiveGames.Utility
{
    public class Ticker : MonoBehaviour
    {
        [SerializeField] private float tickTimer;
        [SerializeField] private float shortTickTimer;

        public delegate void OnNormalTick();
        public static OnNormalTick onNormalTick;

        public delegate void OnShortTick();
        public static OnShortTick onShortTick;

        public delegate void OnSecondTick();
        public static OnSecondTick onSecondTick;

        public delegate void OnFifthTick();
        public static OnFifthTick onFifthTick;

        private float lastTick;
        private float lastShortTick;
        private int tick;

        private void Start() => tick = 0;
        
        private void Update(){
            if(Time.time >= lastShortTick + shortTickTimer){
                onShortTick?.Invoke();
                lastShortTick = Time.time;
            }
            
            if(Time.time >= lastTick + tickTimer){
                tick++;
                
                onNormalTick?.Invoke();
                
                if(tick % 2 == 0) onSecondTick?.Invoke();
                if(tick % 5 == 0) onFifthTick?.Invoke();

                lastTick = Time.time;
            }
        }
    }
}