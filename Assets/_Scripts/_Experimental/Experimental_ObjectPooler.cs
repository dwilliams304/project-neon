using UnityEngine;

namespace ContradictiveGames
{
    public class Experimental_ObjectPooler : MonoBehaviour
    {
        public static Experimental_ObjectPooler Instance;

        public PooledObject Pooled_Bullet;
        public PooledTextObject Pooled_Damage_Text;

        void Awake () => Instance = this;

        void Start(){
            Pooled_Bullet.InstantiateObjectPool(gameObject);
            Pooled_Damage_Text.InstantiateObjectPool(gameObject);
        }
    }
}