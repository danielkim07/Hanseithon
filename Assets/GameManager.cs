//using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Image symbolTexture;
    public GameObject[] dishies;
    public Sprite[] symbolImages;
    public TextMeshProUGUI _321text;
    private int nextDish;
    public Transform parentCanvasTransform;
    public GameObject bgm;

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
        NextDish(); // GO! 표시 후 NextDish 호출
        yield return new WaitForSeconds(0.3f); // GO! 표시 후 잠시 기다립니다.

        _321text.enabled = false; // 카운트다운이 끝난 후 텍스트 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDish()
    {
        print(nextDish);
        GameObject instance = Instantiate(dishies[nextDish], parentCanvasTransform);
        int randNum = Random.Range(0, 8);
        nextDish = randNum;
        symbolTexture.sprite = symbolImages[randNum];
    }
}
