using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    public bool Invincible = false;
    public SpriteRenderer graphics;

    public HealthBar health;
    public Image Fill;
    public Image Border;
    public Image Heart;

    public float InvincibilityDelay;

    public static PlayerHealth Instance;
    public Animator playerAnimation;

    public AudioClip clip;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("beacoup de inventory");
            return;
        }
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        health.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        if (!Invincible)
        {
            AudioManager.Instance.PlayClipAt(clip, transform.position);
            CurrentHealth -= damage;
            health.SetHealth(CurrentHealth);
            if(CurrentHealth <= 0)
            {
                die();
                return;
            }
            Invincible = true;
            StartCoroutine(Invincibility());
            StartCoroutine(NotInvincibile());
        }  
    }
   
    public IEnumerator Invincibility()
    {
        while(Invincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            Fill.color = new Color(Fill.color.r, Fill.color.g, Fill.color.b, 0f);
            Border.color = new Color(Border.color.r, Border.color.g, Border.color.b, 0f);
            Heart.color = new Color(Heart.color.r, Heart.color.g, Heart.color.b, 0f);
            yield return new WaitForSeconds(InvincibilityDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            Fill.color = new Color(Fill.color.r, Fill.color.g, Fill.color.b, 1f);
            Border.color = new Color(Border.color.r, Border.color.g, Border.color.b, 1f);
            Heart.color = new Color(Heart.color.r, Heart.color.g, Heart.color.b, 1f);
            yield return new WaitForSeconds(InvincibilityDelay);
        }
    }

    public IEnumerator NotInvincibile()
    {
        
        yield return new WaitForSeconds(3f);
        Invincible = false;
        
    }

    public void HealPlayer(int hp)
    {
        if(CurrentHealth + hp <= MaxHealth)
        {
            CurrentHealth += hp;
        }
        health.SetHealth(CurrentHealth);
    }

    public void die()
    {
        PlayerMove.Instance.animator.SetTrigger("Dead");
        PlayerMove.Instance.enabled = false;
        PlayerMove.Instance.Collider.enabled = false;
        PlayerMove.Instance.rb.bodyType = RigidbodyType2D.Static;
        GameOverManager.Instance.OnPlayerDeath();
    }

    public void respawn()
    {
        PlayerMove.Instance.animator.SetTrigger("Respawn");
        PlayerMove.Instance.enabled = true;
        PlayerMove.Instance.Collider.enabled = true;
        PlayerMove.Instance.rb.bodyType = RigidbodyType2D.Dynamic;
        CurrentHealth = MaxHealth;
        health.SetMaxHealth(CurrentHealth);

    }
}
