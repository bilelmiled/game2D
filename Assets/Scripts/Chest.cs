using System;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Text interactUI;
    bool isinrange;
    Animator animator;
    private int ChestCoins = 10;
    public AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isinrange)
        {
            OpenChest();
           
        }
    }

    public void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.Instance.AddCoin(ChestCoins);
        AudioManager.Instance.PlayClipAt(audioClip, transform.position);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
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
