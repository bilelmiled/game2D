using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }
    void Start()
    {
        Inventory.Instance.CoinCount = PlayerPrefs.GetInt("coins", 0);
        Inventory.Instance.UpdateTextCoins();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coins", Inventory.Instance.CoinCount);
        if(CurrentSceneManager.Instance.levelToUnlock > PlayerPrefs.GetInt("LevelReached",1))
        {
            PlayerPrefs.SetInt("LevelReached", CurrentSceneManager.Instance.levelToUnlock);
        }
    }
}
