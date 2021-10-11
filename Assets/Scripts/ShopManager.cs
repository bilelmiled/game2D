using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Animator animator;
    public Text Namepnj;
    public GameObject SellButtonPrefab;
    public Transform SellButtonParent;
    public static ShopManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }

    public void OpenShop(Item[] items, string namePNJ)
    {
        Namepnj.text = namePNJ;
        UpdateItemsToSell(items);
        animator.SetBool("isopen", true);
    }

    public void UpdateItemsToSell(Item[] items)
    {
        //delete old buttons
        for (int i = 0; i < SellButtonParent.childCount; i++)
        {
            Destroy(SellButtonParent.GetChild(i).gameObject);
        }
        //instantiate buttons for items
        for (int i = 0; i < items.Length; i++)
        {
            GameObject button = Instantiate(SellButtonPrefab, SellButtonParent);
            SellButtonItem ScriptButton = button.GetComponent<SellButtonItem>();
            ScriptButton.ItemImage.sprite = items[i].image;
            ScriptButton.ItemName.text = items[i].nameItem;
            ScriptButton.ItemPrice.text = items[i].Price.ToString();
            ScriptButton.item = items[i];
        }
    }
    public void EndShop()
    {
        animator.SetBool("isopen", false);
    }


}
