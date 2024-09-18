using System.Collections.Generic;
using ContradictiveGames.Managers;
using UnityEngine;

namespace ContradictiveGames.Utility
{
    public class XPParticleCollector : MonoBehaviour
    {
        [SerializeField] private ParticleSystem ps;

        List<ParticleSystem.Particle> particles = new List<ParticleSystem.Particle>();


        private void Start() {
            ps = GetComponent<ParticleSystem>();
            ps.trigger.AddCollider(GameObject.FindGameObjectWithTag("Player").transform);
        }

        private void OnParticleTrigger(){
            int _part = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, particles);
            for(int i = 0; i < _part; i++){
                ParticleSystem.Particle p = particles[i];
                p.remainingLifetime = 0;
                XPManager.Instance.AddExperience(1);
            }
        }
    }
}
