using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    private bool isinrange;
    private Text interactUI;

    public string PNJName;
    public Item[] itemToSell;
    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isinrange)
        {
            ShopManager.Instance.OpenShop(itemToSell, PNJName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isinrange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isinrange = false;
            interactUI.enabled = false;
            ShopManager.Instance.EndShop();
        }
    }
}
