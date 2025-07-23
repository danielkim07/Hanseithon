//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image symbolTexture;
    public GameObject[] dishies;
    public Sprite[] symbolImages;
    public TextMeshProUGUI _321text;
    private int nextDish;
    public Transform parentCanvasTransform;
    public GameObject bgm;
    private AudioSource ado;
    public AudioClip soundClip;
    public int cleanDishCount = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    private float gameTimer = 60.0f;
    private bool gameStarted = false;
    private int clearDish;
    public Image scoreBoard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*int randNum = Random.Range(0, 8);
        nextDish = randNum;
        symbolTexture.sprite = symbolImages[randNum];
        Thread.Sleep(1000);
        _321text.text = "2";
        Thread.Sleep(1000);
        _321text.text = "1";
        Thread.Sleep(1000);
        _321text.text = "GO!";
        NextDish();
        Thread.Sleep(300);
        _321text.text = "3";
        _321text.enabled = false;*/
        InitializeGame();
        clearDish = CoinManager.instance.day * 4;
        cleanDishCount = 0;
        ado = GetComponent<AudioSource>();
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        _321text.enabled = true; // 텍스트가 처음에 보이도록 설정

        int randNum = Random.Range(0, symbolImages.Length); // symbolImages 배열 크기에 맞춰 Random.Range 사용
        nextDish = randNum;
        symbolTexture.sprite = symbolImages[randNum];

        _321text.text = "3";
        yield return new WaitForSeconds(1f); // 1초 기다립니다.

        _321text.text = "2";
        yield return new WaitForSeconds(1f); // 1초 기다립니다.

        _321text.text = "1";
        yield return new WaitForSeconds(1f); // 1초 기다립니다.

        _321text.text = "GO!";
        bgm.gameObject.SetActive(true);
        gameStarted = true;
        StartCoroutine(GameTimerCountdown());
        NextDish(); // GO! 표시 후 NextDish 호출
        yield return new WaitForSeconds(0.3f); // GO! 표시 후 잠시 기다립니다.

        _321text.enabled = false; // 카운트다운이 끝난 후 텍스트 비활성화
    }

    IEnumerator GameTimerCountdown()
    {
        while (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime; // 경과 시간만큼 타이머 감소
            if (gameTimer < 0) gameTimer = 0; // 타이머가 0 미만으로 내려가지 않도록 보정

            // timerText에 60.00 형식으로 표시
            timerText.text = gameTimer.ToString("F2"); // "F2" 포맷 지정자로 소수점 둘째 자리까지 표시
            
            yield return null; // 다음 프레임까지 기다림
        }

        // 타이머가 0이 되면 게임 종료 로직 수행
        GameOver();
        _321text.enabled = true;
        if(cleanDishCount >= clearDish)
        {
            _321text.text = "CLEAR!";
            if(CoinManager.instance.upgrade != 0)
            {
                CoinManager.instance.coin = CoinManager.instance.coin + cleanDishCount * CoinManager.instance.upgrade;
            } else
            {
                CoinManager.instance.coin = CoinManager.instance.coin + cleanDishCount;
            }
            yield return new WaitForSecondsRealtime(2f);
            scoreBoard.gameObject.SetActive(true);
        } else
        {
            
            _321text.text = "Game Over...";
            CoinManager.instance.coin = 0;
            CoinManager.instance.day = 1;
            CoinManager.instance.upgrade = 0;
            yield return new WaitForSecondsRealtime(2f);
            SceneManager.LoadScene("Title");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        countText.text = cleanDishCount.ToString() + " / " + clearDish.ToString();
    }

    public void NextDish()
    {
        
        ado.Play();
        print(nextDish);
        GameObject instance = Instantiate(dishies[nextDish], parentCanvasTransform);
        instance.transform.SetSiblingIndex(2);
        int randNum = Random.Range(0, 8);
        nextDish = randNum;
        symbolTexture.sprite = symbolImages[randNum];
    }

    void GameOver()
    {
        Debug.Log("Game Over! Cleaned " + cleanDishCount + " dishes.");
        bgm.gameObject.SetActive(false);
        
        Time.timeScale = 0;
    }

    public void InitializeGame()
    {
        Time.timeScale = 1f;
        scoreBoard.gameObject.SetActive(false);
        gameTimer = 60.0f;
        cleanDishCount = 0;
        gameStarted = false;
        timerText.text = gameTimer.ToString("F2");
        countText.text = cleanDishCount.ToString() + " / " + clearDish.ToString();
        _321text.text = "";
        _321text.enabled = true;
        bgm.gameObject.SetActive(false);
        StopAllCoroutines();
    }
}
