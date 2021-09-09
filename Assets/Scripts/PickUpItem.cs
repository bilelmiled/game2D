using System;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    bool isinrange;
    public AudioClip audioClip;
    public Item item;

    // Start is called before the first frame update
    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isinrange)
        {
            TakeItem();
        }
    }

    private void TakeItem()
    {
        Inventory.Instance.content.Add(item);
        AudioManager.Instance.PlayClipAt(audioClip,transform.position);
        interactUI.enabled = false;
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isinrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isinrange = false;
        }
    }
}
