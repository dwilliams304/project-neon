using System.Collections;
using UnityEngine;

namespace ContradictiveGames.Utility
{
    [DisallowMultipleComponent]
    public class DamageFlasher : MonoBehaviour
    {
        [SerializeField] private Color flashColor = Color.white;
        [SerializeField] private float flashTimer = 0.25f;

        private Material mat;
        private Coroutine damageFlashCor;

        private Health health;
        private bool isDead;

        private void Awake(){
            //THIS IS TEMPORARY, Using MeshRenderer.materials[0] is not needed at all!
            mat = GetComponent<MeshRenderer>().materials[0];
            health = GetComponent<Health>();
        }

        private void OnEnable(){
            isDead = false;
            health.onDeath += OnDeath;
        }
        private void OnDisable(){
            health.onDeath -= OnDeath;
        }

        public void DoDamageFlash(){
            if(!isDead) damageFlashCor = StartCoroutine(DamageFlash());
        }

        private void OnDeath(){
            //Used to prevent Coroutine calls on inactive game objects
            isDead = true;
            StopCoroutine(DamageFlash());
        }


        private IEnumerator DamageFlash(){
            mat.SetColor("_DamageFlashColor", flashColor);

            float cur = 0f;
            float elapsedTime = 0f;
            //Lerp DamageFlash Amount from 1 -> 0 (opacity of damage flash color)
            while(elapsedTime < flashTimer){
                elapsedTime += Time.deltaTime;

                cur = Mathf.Lerp(1f, 0f, elapsedTime / flashTimer);
                mat.SetFloat("_FlashAmount", cur);

                yield return null;
            }
        }
    }
}
