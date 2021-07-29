using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogue;
    public bool isinrange;
    private Text interactUI;


    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.E) && isinrange)
        {
            interactUI.enabled = false;
            triggerDialog();
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
        }
    }
    public void triggerDialog()
    {
        DialogManager.Instance.StartDialog(dialogue);
    }
}
