using System.Collections.Generic;
using UnityEngine;

namespace ContradictiveGames.Sounds
{

    [System.Serializable]
    public class Sounds {
        public string soundType;
        public List<AudioClip> audioClips;

        public Sounds(string soundType, List<AudioClip> audioClips){
            this.soundType = soundType;
            this.audioClips = audioClips;
        }
    }

    [System.Serializable]
    public class Sound {
        public string soundType;
        public AudioClip audioClip;

        public Sound(string soundType, AudioClip audioClip){
            this.soundType = soundType;
            this.audioClip = audioClip;
        }
    }

    [CreateAssetMenu(fileName = "Sound List", menuName = "Sounds/Sound List")]
    public class SoundsList : ScriptableObject {
        public List<Sounds> sounds;
        public List<Sound> constantSounds;
    }
}