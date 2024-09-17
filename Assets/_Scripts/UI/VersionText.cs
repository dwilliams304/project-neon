using UnityEngine;
using TMPro;

namespace ContradictiveGames.UI
{
    public class VersionText : MonoBehaviour
    {
        private TMP_Text textAsset;

        void Awake(){
            if(textAsset == null) {
                textAsset = GetComponent<TMP_Text>();
            }
            textAsset.text = "v" + Application.version;
        }
    }
}