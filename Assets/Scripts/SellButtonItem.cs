using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellButtonItem : MonoBehaviour
{
    public Text ItemName;
    public Text ItemPrice;
    public Image ItemImage;

    public Item item;
    public void BuyItem()
    {
        Inventory inventory = Inventory.Instance;
        if(inventory.CoinCount > item.Price)
        {
            inventory.content.Add(item);
            inventory.CoinCount -= item.Price;
            inventory.UpdateTextCoins();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
