using System.Collections.Generic;
using ContradictiveGames.Player;
using UnityEngine;

namespace ContradictiveGames.Utility
{
    public class GoldParticleCollector : MonoBehaviour
    {
        private ParticleSystem ps;

        List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();
        PlayerInventory playerInventory;


        private void Start() {
            ps = GetComponent<ParticleSystem>();
            ps.trigger.AddCollider(GameObject.FindGameObjectWithTag("ParticleCollector").transform);
            playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        }

        private void OnParticleTrigger(){
            int _part = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
            for(int i = 0; i < _part; i++){
                ParticleSystem.Particle p = particles[i];
                p.remainingLifetime = 0;
                playerInventory.AddCurrency(1);
            }
        }
    }
}
