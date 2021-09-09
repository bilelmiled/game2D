using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public int CoinCount;
    public Button consume;
    public Button next;
    public Button previous;
    public Image ItemImage;
    public Sprite invisible;
    public Text ItemDesc;

    public Text Coinstext;

    public List<Item> content = new List<Item>();
    private int contentCurrentIndex = 0;

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
    private void Start()
    {

    }
    private void Update()
    {
        UpdateImageItem();
    }

    public void UpdateImageItem()
    {
        if(content.Count!=0)
        {
            consume.interactable = true;
            next.interactable = true;
            previous.interactable = true;
            ItemImage.sprite = content[contentCurrentIndex].image;
            ItemDesc.text = content[contentCurrentIndex].nameItem;
        }
        else if (content.Count == 0)
        {
            consume.interactable = false;
            next.interactable = false;
            previous.interactable = false;
            ItemImage.sprite = invisible;
            ItemDesc.text = "";
        }
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

    public void ConsumeItem()
    {
        Item currentItem = content[contentCurrentIndex];
        PlayerHealth.Instance.HealPlayer(currentItem.hpAdd);
        PlayerEffect.Instance.AddSpeed(currentItem.jumpAdd, currentItem.speedDuration);
        content.Remove(currentItem);
        GetNextItem();
    }

    public void PlayerEffectAfterPotion(int speed)
    {
        if(speed > 0)
        {

        }
    }

    public void GetNextItem()
    {
        contentCurrentIndex++;
        if (contentCurrentIndex > content.Count-1)
        {
            contentCurrentIndex = 0;
        }
        UpdateImageItem();
    }

    public void GetPreviousItem()
    {
        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateImageItem();
    }
}
