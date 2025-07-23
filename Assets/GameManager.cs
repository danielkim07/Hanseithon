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
        _321text.enabled = true; // �ؽ�Ʈ�� ó���� ���̵��� ����

        int randNum = Random.Range(0, symbolImages.Length); // symbolImages �迭 ũ�⿡ ���� Random.Range ���
        nextDish = randNum;
        symbolTexture.sprite = symbolImages[randNum];

        _321text.text = "3";
        yield return new WaitForSeconds(1f); // 1�� ��ٸ��ϴ�.

        _321text.text = "2";
        yield return new WaitForSeconds(1f); // 1�� ��ٸ��ϴ�.

        _321text.text = "1";
        yield return new WaitForSeconds(1f); // 1�� ��ٸ��ϴ�.

        _321text.text = "GO!";
        bgm.gameObject.SetActive(true);
        gameStarted = true;
        StartCoroutine(GameTimerCountdown());
        NextDish(); // GO! ǥ�� �� NextDish ȣ��
        yield return new WaitForSeconds(0.3f); // GO! ǥ�� �� ��� ��ٸ��ϴ�.

        _321text.enabled = false; // ī��Ʈ�ٿ��� ���� �� �ؽ�Ʈ ��Ȱ��ȭ
    }

    IEnumerator GameTimerCountdown()
    {
        while (gameTimer > 0)
        {
            gameTimer -= Time.deltaTime; // ��� �ð���ŭ Ÿ�̸� ����
            if (gameTimer < 0) gameTimer = 0; // Ÿ�̸Ӱ� 0 �̸����� �������� �ʵ��� ����

            // timerText�� 60.00 �������� ǥ��
            timerText.text = gameTimer.ToString("F2"); // "F2" ���� �����ڷ� �Ҽ��� ��° �ڸ����� ǥ��
            
            yield return null; // ���� �����ӱ��� ��ٸ�
        }

        // Ÿ�̸Ӱ� 0�� �Ǹ� ���� ���� ���� ����
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
