using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScene : MonoBehaviour
{
    public void SceneMove()
    {
        if(CoinManager.instance != null)
        {
            CoinManager.instance.coin = 0;
            CoinManager.instance.day = 1;
            CoinManager.instance.upgrade = 0;
        }
        SceneManager.LoadScene("MainGame");
    }
}
