using System.Collections.Generic;
using UnityEngine;

namespace ContradictiveGames.Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        private float previousTimeScale = 1f;

        public delegate void OnPreventPlayerInput(bool prevent);
        public OnPreventPlayerInput onPreventPlayerInput;

        [SerializeField] private List<GameObject> openPanels = new List<GameObject>();

        // [System.Serializable]
        // public class GamePanel {
        //     public GameObject panel;
        //     public KeyCode key;
        // }

        [Header("Specific Panels")]
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private KeyCode pauseKey;

        void Awake(){
            if(Instance == null){
                Instance = this;
            }
            else if (Instance != this){
                Destroy(this);
            }

            DontDestroyOnLoad(this);
        }


        //DIRTY, CHANGE ME PLEASE
        void Update(){
            if(Input.GetKeyDown(pauseKey)){
                TogglePanel(pausePanel);
            }
        }

        public void OnDragMenu(bool preventInput = false){
            onPreventPlayerInput?.Invoke(preventInput);
        }

        public void TogglePanel(GameObject panel){
            if(openPanels.Contains(panel)) {
                ClosePanel(panel);
                return;
            }
            else if(!ArePanelsOpen()){
                previousTimeScale = Time.timeScale;
                openPanels.Add(panel);
                panel.SetActive(true);
                Time.timeScale = 0f;
            }
            else {
                openPanels.Add(panel);
                panel.SetActive(true);
                Debug.Log("Panels already open, don't need to change time scale");
            }
            onPreventPlayerInput?.Invoke(true);
        }

        private void ClosePanel(GameObject panel){
            if(!openPanels.Contains(panel)) {
                Debug.LogError("Close panel called on a panel that isn't open. FIX THIS");
            }
            openPanels.Remove(panel);
            panel.SetActive(false);
            if(!ArePanelsOpen()){
                Time.timeScale = previousTimeScale;
                onPreventPlayerInput?.Invoke(false);
            }
        }


        public bool ArePanelsOpen(){
            if(openPanels.Count == 0) return false;
            else return true;
        }
    }
}