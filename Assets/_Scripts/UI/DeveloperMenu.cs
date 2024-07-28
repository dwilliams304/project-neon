using UnityEngine;



public class DeveloperMenu : MonoBehaviour
{
    [SerializeField] private KeyCode devMenuButton;
    [SerializeField] private GameObject panelToOpen;


    private void Update(){
        if (Input.GetKeyDown(devMenuButton)){
            OpenDevMenu();
        }
    }


    private void OpenDevMenu(){
        // if(panelToOpen.activeInHierarchy){
        //     panelToOpen.SetActive(false);
        // }
        // else{
        //     panelToOpen.SetActive(true);
        // }
        panelToOpen.SetActive(!panelToOpen.activeInHierarchy);
    }   
}
