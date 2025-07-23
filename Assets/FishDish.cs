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

    private void Update()
    {
        KeyDown();

        
    }

    private void OnEnable()
    {
        transform.position = new Vector2(0, 0);
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
        transform.position = new Vector2 (transform.position.x - 100, transform.position.y);
        if (transform.position.x <= -2000) {
            gameObject.SetActive(false);
        }
    }

    private void KeyDown()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))
        {
            if (currentIndex < images.Length - 1)
            {
                currentIndex++;
                leftHand.sprite = images[currentIndex - 1];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (currentIndex == images.Length - 1)
            {
                leftHand.sprite = images[currentIndex];
                leave = true;
            }
        }
    }
}
