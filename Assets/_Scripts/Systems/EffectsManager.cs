using UnityEngine;
using Cinemachine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance;

    private CinemachineVirtualCamera cmVCam;
    private CinemachineBasicMultiChannelPerlin cmNoise;

    private void Awake(){
        Instance = this;
        cmVCam = FindObjectOfType<CinemachineVirtualCamera>();
        cmNoise = cmVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


}
