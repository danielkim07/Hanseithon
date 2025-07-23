using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishDish : MonoBehaviour
{
    public Image leftHand;
    public Sprite[] images;
    private int currentIndex = 0;
    private bool leave = false;
    public GameManager gameManager;
    private int autoclick;

    private void Update()
    {
        KeyDown();

        if (autoclick != 0)
        {
            KeyClick();
            autoclick--;
        }
    }

    private void OnEnable()
    {
        autoclick = CoinManager.instance.upgrade;
        print(autoclick);
        print(CoinManager.instance.upgrade);
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }



    private void FixedUpdate()
    {
        

        if (leave)
        {
            Leave();
        }
        
    }

    private void Leave()
    {
        if(CoinManager.instance.upgrade <= 14)
        {
            transform.position = new Vector2(transform.position.x - 250, transform.position.y);
        } else if(CoinManager.instance.upgrade <= 40)
        {
            transform.position = new Vector2(transform.position.x - 500, transform.position.y);
        } else if(CoinManager.instance.upgrade <= 70)
        {
            transform.position = new Vector2(transform.position.x - 1000, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - 2000, transform.position.y);
        }
        if (transform.position.x <= -2000)
        {
            Destroy(gameObject);
            gameManager.NextDish();
        }
    }

    private void KeyDown()
    {
        /*if(Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.J) && Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.K))
        {
            KeyClick();
            KeyClick();
            KeyClick();
            KeyClick();
        } */
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.Semicolon))
        {
            KeyClick();
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex == images.Length - 1 && !leave)
            {
                gameManager.cleanDishCount++;
                leftHand.sprite = images[currentIndex];
                leave = true;

            }
        }
    }

    private void KeyClick()
    {
        if (currentIndex < images.Length - 1)
        {
            currentIndex++;
            leftHand.sprite = images[currentIndex - 1];
        }
    }
}
