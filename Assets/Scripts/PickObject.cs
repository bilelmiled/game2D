using UnityEngine;

public class PickObject : MonoBehaviour
{
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlayClipAt(audioClip, transform.position);
            Inventory.Instance.AddCoin(1);
            CurrentSceneManager.Instance.CoinPickedUpInThisScene++;
            Destroy(gameObject);
        }
    }
}
