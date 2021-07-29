
using UnityEngine;

public class CameroFollow : MonoBehaviour
{
    /* public Transform Player;
     Vector3 range;

     void Awake()
     {
         range = transform.position - Player.position;
     }

     void FixedUpdate()
     {

         transform.position = new Vector3(range.x + Player.position.x, transform.position.y, range.z + Player.position.z);
     }*/
    public Transform Player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
