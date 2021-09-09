using System.Linq;
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

        string[] itemSaved = PlayerPrefs.GetString("InventoryItems","").Split(',');

        for (int i = 0; i < itemSaved.Length; i++)
        {
            if(itemSaved[i] != "")
            {
                int id = int.Parse(itemSaved[i]);
                Item itemCurrent = ItemsDatabase.Instance.allItems.Single(x => x.id == id);
                Inventory.Instance.content.Add(itemCurrent);
            }
        }
        Inventory.Instance.UpdateImageItem();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coins", Inventory.Instance.CoinCount);
        if(CurrentSceneManager.Instance.levelToUnlock > PlayerPrefs.GetInt("LevelReached",1))
        {
            PlayerPrefs.SetInt("LevelReached", CurrentSceneManager.Instance.levelToUnlock);
        }

        string itemsInInventory = string.Join(",", Inventory.Instance.content.Select(x => x.id));

        PlayerPrefs.SetString("InventoryItems", itemsInInventory);


       
    }
}
