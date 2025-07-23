using UnityEngine;

public class SettimngUiShow : MonoBehaviour
{


    public void ShowToggle()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
    }
}
