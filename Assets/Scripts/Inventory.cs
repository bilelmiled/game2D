using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int CoinCount;

    public Text Coinstext;

    public static Inventory Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }

    public void AddCoin(int coin)
    {
        CoinCount += coin;
        UpdateTextCoins();
    }

    public void remove(int coin)
    {
        CoinCount -= coin;
        UpdateTextCoins();
    }

    public void UpdateTextCoins()
    {
        Coinstext.text = CoinCount.ToString();
    }
}
