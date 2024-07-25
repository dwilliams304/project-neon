using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private float previousTimeScale = 1f;

    public delegate void OnPreventPlayerInput(bool prevent);
    public OnPreventPlayerInput onPreventPlayerInput;

    [SerializeField] private List<GameObject> openPanels = new List<GameObject>();

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        else if (Instance != this){
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void OnDragMenu(bool preventInput = false){
        onPreventPlayerInput?.Invoke(preventInput);
    }

    public void OpenPanel(GameObject panel){
        if(openPanels.Contains(panel)) return;
        else if(!ArePanelsOpen()){
            previousTimeScale = Time.timeScale;
            openPanels.Add(panel);
            panel.SetActive(true);
            Debug.Log($"Storing time scale: {previousTimeScale} // and pausing");
            Time.timeScale = 0f;
        }
        else {
            openPanels.Add(panel);
            panel.SetActive(true);
            Debug.Log("Panels already open, don't need to change time scale");
        }
        onPreventPlayerInput?.Invoke(true);
    }

    public void ClosePanel(GameObject panel){
        if(!openPanels.Contains(panel)) {
            Debug.LogError("Close panel called on a panel that isn't open. FIX THIS");
            return;
        }
        openPanels.Remove(panel);
        panel.SetActive(false);
        Debug.Log("Closing Panel");
        if(!ArePanelsOpen()){
            Time.timeScale = previousTimeScale;
            onPreventPlayerInput?.Invoke(false);
            Debug.Log($"Setting time back to regular scale of: {previousTimeScale}");
        }
    }


    public bool ArePanelsOpen(){
        if(openPanels.Count == 0) return false;
        else return true;
    }
}
