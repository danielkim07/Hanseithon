using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameScene : MonoBehaviour
{
    public void SceneMove()
    {
        SceneManager.LoadScene("MainGame");
    }
}
