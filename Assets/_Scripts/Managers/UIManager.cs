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

        [Header("Pause Menu")]
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private KeyCode pauseKey;

        [Header("Dev Menu")]
        [SerializeField] private GameObject devMenuPanel;
        [SerializeField] private KeyCode devMenuKey;


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
            else if(Input.GetKeyDown(devMenuKey)){
                OpenDevMenu();
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


        private bool ArePanelsOpen(){
            if(openPanels.Count == 0) return false;
            else return true;
        }


        private void OpenDevMenu(){
            devMenuPanel.SetActive(!devMenuPanel.activeInHierarchy);
        }
    }
}