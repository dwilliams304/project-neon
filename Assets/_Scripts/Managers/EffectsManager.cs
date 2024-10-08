using UnityEngine;
using Cinemachine;
using System.Collections;
using ContradictiveGames.Experimental;

namespace ContradictiveGames.Managers
{
    public class EffectsManager : MonoBehaviour
    {
        public static EffectsManager Instance;

        private CinemachineVirtualCamera cam;
        private CinemachineBasicMultiChannelPerlin camNoise;

        [Header("Particles")]
        [SerializeField] private float timeToWaitForXPDrag = 1f;


        [Header("Damage Flash Colors")]
        public Color NormalDamageFlashColor;
        public Color CritDamageFlashColor;

        
        Experimental_ObjectPooler objPInstance;

        WaitForSeconds xpDragWait;
        Quaternion particleRot;


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

        private void Start() {
            objPInstance = Experimental_ObjectPooler.Instance;
            particleRot = Quaternion.Euler(-90, 0, 0);
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


        public void DropXPParticles(Vector3 pos, int xpToDrop){
            ParticleSystem ps = objPInstance.XPDrop_Prefab.GetPooledObject(pos, particleRot).GetComponent<ParticleSystem>();
            StartCoroutine(WaitForParticlesToDrag(ps.externalForces));
            ps.Emit(Mathf.CeilToInt(xpToDrop * GameManager.Instance.enemyXPDropScale));
            ps.Play();
        }
        public void DropCurrencyParticles(Vector3 pos, int goldToDrop){
            ParticleSystem ps = objPInstance.CurrencyDrop_Prefab.GetPooledObject(pos, particleRot).GetComponent<ParticleSystem>();
            StartCoroutine(WaitForParticlesToDrag(ps.externalForces));
            ps.Emit(goldToDrop);
            ps.Play();
        }

        private IEnumerator WaitForParticlesToDrag(ParticleSystem.ExternalForcesModule ef){
            ef.enabled = false;
            yield return xpDragWait;
            ef.enabled = true;
        }
    }
}