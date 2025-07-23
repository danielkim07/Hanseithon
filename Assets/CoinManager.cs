using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // �̱��� �ν��Ͻ�
    public int coin;
    public int day;
    public int upgrade;
    public int high_Score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� ����Ǿ �ı����� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� ������ �ڽ��� �ı�
        }
    }
}
