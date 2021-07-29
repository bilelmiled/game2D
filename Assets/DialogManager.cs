using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Animator animator;
    public Text Namepnj;
    public Text dialogtext;

    public Queue<string> sentences;

    public static DialogManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
        sentences = new Queue<string>();
    }


    public void StartDialog(Dialog dialogue)
    {
        animator.SetBool("isopen", true);
        Namepnj.text = dialogue.name.ToUpper();

        sentences.Clear();

        foreach (string item in dialogue.sentences)
        {
            sentences.Enqueue(item);
        }

        Displaynextsentence();
    }

    public void Displaynextsentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        // dialogtext.text = sentence.ToUpper();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    private void EndDialog()
    {
        animator.SetBool("isopen", false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogtext.text = "";
        foreach (char item in sentence.ToUpper().ToCharArray())
        {
            dialogtext.text += item;
            yield return new WaitForSeconds(0.1f);
          //  yield return null;
        }
    }
}
