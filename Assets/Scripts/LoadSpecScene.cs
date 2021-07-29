using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecScene : MonoBehaviour
{
    private Animator FadeSystem;
    public string namescene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(loadnextscene());
        }
    }
    public IEnumerator loadnextscene()
    {
        LoadAndSaveData.Instance.SaveData();
        FadeSystem.SetTrigger("FadeIN");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(namescene);
    }
    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
}
