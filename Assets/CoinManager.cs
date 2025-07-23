using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // 싱글톤 인스턴스
    public int coin;
    public int day;
    public int upgrade;
    public int high_Score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 변경되어도 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있으면 자신을 파괴
        }
    }
}
