using UnityEngine;
using TMPro;


namespace ContradictiveGames.UI
{
    public class FPSCounter : MonoBehaviour
    {
        float fps;
        float updateTimer = 0.4f;

        [SerializeField] private TMP_Text fpsText;

        void Update(){
            UpdateFPSText();
        }

        void UpdateFPSText(){
            updateTimer -= Time.deltaTime;
            if(updateTimer <= 0){
                fps = 1f / Time.unscaledDeltaTime;
                fpsText.text = Mathf.RoundToInt(fps).ToString();
                updateTimer = 0.4f;
            }
        }
    }
}