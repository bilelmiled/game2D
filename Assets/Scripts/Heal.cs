using UnityEngine;

public class Heal : MonoBehaviour
{
    public AudioClip clip;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClipAt(clip, transform.position);
            PlayerHealth.Instance.HealPlayer(25);
            Destroy(gameObject);
        }
    }
}
