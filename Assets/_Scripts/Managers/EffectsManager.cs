using UnityEngine;
using Cinemachine;
using System;
using System.Collections;

namespace ContradictiveGames.Managers
{
    public class EffectsManager : MonoBehaviour
    {
        public static EffectsManager Instance;

        private CinemachineVirtualCamera cam;
        private CinemachineBasicMultiChannelPerlin camNoise;

        [SerializeField] private GameObject XPDropPrefab;

        [SerializeField] private float timeToWaitForXPDrag = 1f;

        WaitForSeconds xpDragWait;


        //Camera shake variables
        private float shakeTimer;
        private float shakeDuration;
        private float startingIntensity;

        private void Awake(){
            Instance = this;
            cam = FindObjectOfType<CinemachineVirtualCamera>();
            camNoise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            xpDragWait = new WaitForSeconds(timeToWaitForXPDrag);
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
            ParticleSystem ps = Instantiate(XPDropPrefab, pos, Quaternion.Euler(-90, 0, 0)).GetComponent<ParticleSystem>();
            // ps.burstCount = xpToDrop;
            // var ef = ps.externalForces;
            // ef.enabled = false;
            StartCoroutine(WaitForParticlesToDrag(ps));
            ps.Emit(Mathf.CeilToInt(xpToDrop * GameManager.Instance.enemyXPDropScale));
            ps.Play();
        }

        private IEnumerator WaitForParticlesToDrag(ParticleSystem ps){
            var ef = ps.externalForces;
            ef.enabled = false;
            yield return xpDragWait;
            ef.enabled = true;
        }
    }
}