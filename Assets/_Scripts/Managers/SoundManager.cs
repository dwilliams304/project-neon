using ContradictiveGames.Sounds;
using UnityEngine;


namespace ContradictiveGames.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [Header("General Settings")]
        [SerializeField] private Vector2 randomPitchRange;
        [SerializeField] private float commonClipDelay;

        [Header("Audio Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private AudioSource effectsSource_RandomPitch;
        [SerializeField] private AudioSource worldSource;
        [SerializeField] private AudioSource uiSource;

        [Header("UI Sounds")]
        [SerializeField] private AudioClip buttonHover;
        [SerializeField] private AudioClip buttonClick;
        [SerializeField] private AudioClip buttonConfirm;

        [Header("Common Sounds")]
        public AudioClip xpGain;



        //private vars
        private float lastClipPlayed;
        private int currentMusicTrack;

        private void Awake(){
            if(Instance == null) {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else{
                Destroy(gameObject);
            }

            lastClipPlayed = Time.time;
            currentMusicTrack = 0;
            // PlayMusic(musicTracks.audioClips[currentMusicTrack]);
        }


        /// <summary>
        /// Used to play a random sound effect from a list of AudioClips.
        /// </summary>
        public void PlayRandomSoundEffect(SoundsList soundsList, string soundType, bool commonClip = false, bool randomPitch = false){
            AudioClip clip = null;
            for(int i = 0; i < soundsList.sounds.Count; i++){
                if(soundType == soundsList.sounds[i].soundType){
                    clip = soundsList.sounds[i].audioClips.RandomFromList();
                }
            }
            if(clip != null){
                if(commonClip) {
                    PlayCommonSoundEffect(clip, randomPitch);
                    return;
                }
                else if(!commonClip && randomPitch){
                    PlaySoundEffectRandomPitch(clip);
                    return;
                }
                else effectsSource.PlayOneShot(clip);
            }
            else Debug.Log("<color=red>Could not find AudioClip of type: </color>" + soundType);
    
        }


        /// <summary>
        /// Used to play a sound effect with a delay in between sounds to prevent overlap of audio clips.
        /// </summary>
        public void PlayCommonSoundEffect(AudioClip audioClip, bool randomPitch = false){
            if(Time.time > lastClipPlayed + commonClipDelay){
                lastClipPlayed = Time.time;
                if(!randomPitch) effectsSource.PlayOneShot(audioClip);
                else PlaySoundEffectRandomPitch(audioClip);
            }
        }

        private void PlaySoundEffectRandomPitch(AudioClip audioClip){
            effectsSource_RandomPitch.pitch = Random.Range(randomPitchRange.x, randomPitchRange.y);
            effectsSource_RandomPitch.PlayOneShot(audioClip);
        }


        public void PlayWorldSound(){
            Debug.Log("Trigger some kind of world sound!"); //Maybe use this in case of utilizing spatial audio?
        }

        public void PlayMusic(AudioClip musicTrack){
            Debug.Log("Play some music (probably a random track, or cycle to next track in list)");
        }


        #region UI Sounds
        public void UIHoverSound() => uiSource.PlayOneShot(buttonHover);
        public void UIClickSound() => uiSource.PlayOneShot(buttonClick);
        public void UIConfirmSound() => uiSource.PlayOneShot(buttonConfirm);
        #endregion

    }
}
