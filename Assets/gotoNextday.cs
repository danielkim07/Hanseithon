using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoNextday : MonoBehaviour
{
    public void SceneNextdayLoad()
    {
        CoinManager.instance.day++;
        SceneManager.LoadScene("MainGame");
    }
}
