using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void SceneMove()
    {
        if(CoinManager.instance != null)
        {
            CoinManager.instance.day++;
        }
        SceneManager.LoadScene("MainGame");
    }
}
