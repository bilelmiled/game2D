
using UnityEngine;

public class KillEnnemi : MonoBehaviour
{
    public GameObject objdestroy;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClipAt(clip, transform.position);
            Destroy(transform.parent.gameObject);
        }
    }
}
