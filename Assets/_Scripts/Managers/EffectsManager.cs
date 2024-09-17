using UnityEngine;
using Cinemachine;

namespace ContradictiveGames.Managers
{
    public class EffectsManager : MonoBehaviour
    {
        public static EffectsManager Instance;

        private CinemachineVirtualCamera cam;
        private CinemachineBasicMultiChannelPerlin camNoise;

        [SerializeField] private GameObject XPDropPrefab;


        //Camera shake variables
        private float shakeTimer;
        private float shakeDuration;
        private float startingIntensity;

        private void Awake(){
            Instance = this;
            cam = FindObjectOfType<CinemachineVirtualCamera>();
            camNoise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update(){
            if(shakeTimer > 0){
                shakeTimer -= Time.deltaTime;
                if(shakeTimer <= 0f){
                    camNoise.m_AmplitudeGain = 0f;
                    Mathf.Lerp(startingIntensity, 0f, 1 - (shakeTimer / shakeDuration));
                }
            }
        }


        public void CameraShake(float intensity, float time){
            camNoise.m_AmplitudeGain = intensity;
            camNoise.m_FrequencyGain = time;
            shakeTimer = time;
            shakeDuration = time;
            startingIntensity = intensity;
        }


        public void CallForXPParticles(Vector3 pos, int xpToDrop){
            ParticleSystem ps = Instantiate(XPDropPrefab, pos, Quaternion.identity).GetComponent<ParticleSystem>();
            // ps.burstCount = xpToDrop;
            var em = ps.emission;
            em.rateOverTime = 0;
            em.SetBurst(0, new ParticleSystem.Burst(0f, (short)xpToDrop, (short)xpToDrop));
            // ps.Emit(xpToDrop);
            // ps.Play();
        }
    }
}