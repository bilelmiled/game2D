using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiPatrol : MonoBehaviour
{
   
    public float speed;
    public Transform[] waypoints;

    public int DamageEnnemi;
    public SpriteRenderer graphics;

    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[0];
        graphics.flipX = true;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(DamageEnnemi);
        }
    }
}
