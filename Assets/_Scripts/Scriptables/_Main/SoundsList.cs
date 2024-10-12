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

    [CreateAssetMenu(fileName = "Sound List", menuName = "Sounds/Sound List")]
    public class SoundsList : ScriptableObject {
        public List<Sounds> sounds;
    }
}