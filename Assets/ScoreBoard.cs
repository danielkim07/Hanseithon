using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI thisScore;
    public TextMeshProUGUI highScore;

    public GameManager gameManager;

    private void OnEnable()
    {
        thisScore.text = gameManager.cleanDishCount.ToString();
        if(gameManager.cleanDishCount > CoinManager.instance.high_Score)
        {
            CoinManager.instance.high_Score = gameManager.cleanDishCount;
        }
        highScore.text = CoinManager.instance.high_Score.ToString();
    }
}
