using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
    private bool isrange;
    private PlayerMove playermove;
    public BoxCollider2D Collider;
    public Rigidbody2D body;
    private Text interactLadder;

    void Start()
    {
        playermove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        interactLadder = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    void Update()
    {
        if(isrange && playermove.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playermove.isClimbing = false;
            Collider.isTrigger = false;
            body.gravityScale = 1;

            return;
        }
        if(isrange && Input.GetKeyDown(KeyCode.E))
        {
            playermove.isClimbing = true;
            Collider.isTrigger = true;
            body.gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isrange = false;
            playermove.isClimbing = false;
            Collider.isTrigger = false;
            body.gravityScale = 1;
            interactLadder.enabled = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isrange = true;
            interactLadder.enabled = true;
        }
    }
}
