using UnityEngine;
using Cinemachine;

namespace ContradictiveGames.Managers
{
    public class EffectsManager : MonoBehaviour
    {
        public static EffectsManager Instance;

        private CinemachineVirtualCamera cam;
        private CinemachineBasicMultiChannelPerlin camNoise;


        //Camera shake variables
        private float shakeTimer;
        private float shakeDuration;
        private float startingIntensity;

        private void Awake(){
            Instance = this;
            cam = FindObjectOfType<CinemachineVirtualCamera>();
            camNoise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void CameraShake(float intensity, float time){
            camNoise.m_AmplitudeGain = intensity;
            camNoise.m_FrequencyGain = time;
            shakeTimer = time;
            shakeDuration = time;
            startingIntensity = intensity;
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


    }
}