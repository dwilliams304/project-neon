using System.Collections;
using System.Collections.Generic;
using ContradictiveGames.Utility;
using UnityEngine;


namespace ContradictiveGames.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private AudioSource effectsSource_RandomPitch;
        [SerializeField] private AudioSource worldSource;
        [SerializeField] private AudioSource uiSource;




        private void Awake(){
            if(Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else{
                Destroy(gameObject);
            }
        }


        /// <summary>
        /// Used to play a random sound effect from a list of AudioClips.
        /// </summary>
        public void PlayRandomSoundEffect(){

        }


        /// <summary>
        /// Used to play a sound effect with a delay in between sounds to prevent overlap of audio clips.
        /// </summary>
        public void PlaySoundEffect(bool randomPitch = false){
            if(randomPitch){
                effectsSource.PlayOneShot(null);
            }
            else{
                effectsSource_RandomPitch.pitch = Random.Range(0.95f, 1.05f);
                effectsSource_RandomPitch.PlayOneShot(null);
            }
        }


        public void PlayWorldSound(){
            Debug.Log("Trigger some kind of world sound!"); //Maybe use this in case of utilizing spatial audio?
        }


        public void PlayUISound(){
            Debug.Log("Play a UI Sound!");
        }


        public void PlayMusic(){
            Debug.Log("Play some music (probably a random track, or cycle to next track in list)");
        }
    }
}
