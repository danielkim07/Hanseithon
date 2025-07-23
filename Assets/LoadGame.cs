using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void SceneMove()
    {
        SceneManager.LoadScene("MainGame");
    }
}
