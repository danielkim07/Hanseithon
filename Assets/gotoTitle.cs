using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoTitle : MonoBehaviour
{
    public void SceneTitleLoad()
    {
        SceneManager.LoadScene("Title");
    }
}
