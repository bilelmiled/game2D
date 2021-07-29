using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private Animator FadeSystem;


    private void Awake()
    {
        FadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //collision.transform.position = GameObject.FindGameObjectWithTag("PlayerSpawn").transform.position;
            StartCoroutine(loadnextscene(collision));
        }
    }
    public IEnumerator loadnextscene(Collider2D collision)
    {
        FadeSystem.SetTrigger("FadeIN");
        yield return new WaitForSeconds(1f);
        collision.transform.position = CurrentSceneManager.Instance.RespawnPoint;
    }
}
