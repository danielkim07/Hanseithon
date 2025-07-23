using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gangText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI priceText;
    public Button buybtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        coinText.text = CoinManager.instance.coin.ToString();
        gangText.text = CoinManager.instance.upgrade.ToString() + "�� / �İ�";
        dayText.text = CoinManager.instance.day.ToString() + "����";
        if (CoinManager.instance.upgrade == 0)
        {
            priceText.text = "100����";
        }
        else
        {
            priceText.text = CoinManager.instance.upgrade * 150 + "����";
        }
        if (CoinManager.instance.coin < CoinManager.instance.upgrade * 150 || CoinManager.instance.coin < 100)
        {
            buybtn.enabled = false;
        }
    }

    private void LateUpdate()
    {
        coinText.text = CoinManager.instance.coin.ToString();
        gangText.text = CoinManager.instance.upgrade.ToString() + "�� / �İ�";
        dayText.text = CoinManager.instance.day.ToString() + "����";
        if(CoinManager.instance.upgrade == 0 )
        {
            priceText.text = "100����";
        } else
        {
            priceText.text = CoinManager.instance.upgrade * 150 + "����";
        }
        if(CoinManager.instance.coin < CoinManager.instance.upgrade * 150 || CoinManager.instance.coin < 100)
        {
            buybtn.enabled = false;
        }
    }
}
