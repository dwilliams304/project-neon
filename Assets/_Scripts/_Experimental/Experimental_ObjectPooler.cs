using UnityEngine;
using ContradictiveGames.ObjectPooling;

namespace ContradictiveGames.Experimental
{
    public class Experimental_ObjectPooler : MonoBehaviour
    {
        public static Experimental_ObjectPooler Instance;

        public PooledObject Pooled_Bullet;
        public PooledObject XPDrop_Prefab;
        public PooledObject GoldDrop_Prefab;
        public PooledTextObject Pooled_Damage_Text;


        void Awake () => Instance = this;

        void Start(){
            Pooled_Bullet.InstantiateObjectPool(gameObject);
            Pooled_Damage_Text.InstantiateObjectPool(gameObject);
            XPDrop_Prefab.InstantiateObjectPool(gameObject);
            GoldDrop_Prefab.InstantiateObjectPool(gameObject);
        }
    }
}