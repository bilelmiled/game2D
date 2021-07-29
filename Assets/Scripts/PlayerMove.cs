
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float ClimbSpeed;


    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    private float horizontalMovement;
    private float verticalMovement;


    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public Animator animator;

    public Rigidbody2D rb;
    public CapsuleCollider2D Collider;
    private Vector3 velocity = Vector3.zero;

    public static PlayerMove Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }

    void Update()
    {


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        Flip(horizontalMovement);

        float CharacterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", CharacterVelocity);
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * ClimbSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,collisionLayer);
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        if(!isClimbing)
        {
            Vector3 targetVelocityHor = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocityHor, ref velocity, .05f);

            if (isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }
        else
        {
            Vector3 targetVelocityVer = new Vector2(0f ,_verticalMovement );
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocityVer, ref velocity, .05f);
        }
        
    }   

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(_velocity < -0.1f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}


