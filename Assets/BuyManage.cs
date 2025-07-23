using UnityEngine;

public class BuyManage : MonoBehaviour
{
    public void BuyClick()
    {
        if(CoinManager.instance.upgrade == 0)
        {
            if(CoinManager.instance.coin >= 100)
            {
                CoinManager.instance.coin = CoinManager.instance.coin - 100;
                CoinManager.instance.upgrade++;
            }
        } else
        {
            if (CoinManager.instance.coin >= CoinManager.instance.upgrade * 150)
            {
                CoinManager.instance.coin = CoinManager.instance.coin - CoinManager.instance.upgrade * 150;
                CoinManager.instance.upgrade++;
            }
        }
    }
}
