using UnityEngine;

namespace ContradictiveGames.Loot
{
    public class LootObject : MonoBehaviour, IInteractable {
        public LootDrop loot;

        public void OnInteract()
        {
            Debug.Log($"Picked up loot! Object: {loot}");
        }
    }
}