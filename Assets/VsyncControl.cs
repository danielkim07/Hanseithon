using UnityEngine;
using UnityEngine.UI;

public class VsyncControl : MonoBehaviour
{
    public bool isVSyncEnabled;
    public Image buttonImage;
    public Sprite checkDis;
    public Sprite checkEn;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        isVSyncEnabled = false;
        isVSyncEnabled = QualitySettings.vSyncCount > 0;
    }

    public void ToggleVSync()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            // VSync가 꺼져있으면 켠다.
            QualitySettings.vSyncCount = 1;
            isVSyncEnabled = true;
            Debug.Log("VSync has been enabled.");
            buttonImage.sprite = checkEn;
        }
        else
        {
            // VSync가 켜져있으면 끈다.
            QualitySettings.vSyncCount = 0;
            isVSyncEnabled = false;
            Debug.Log("VSync has been disabled.");
            buttonImage.sprite = checkDis;
        }
    }
}
