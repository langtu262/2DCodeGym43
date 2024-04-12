using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour,ICanTakeDamage
{
    [SerializeField ]private float moveSpeed = 5.0f;
    [SerializeField] private float jumFore = 5.0f;
    [SerializeField] Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGround;
    private bool facingRight = true;
    private int idRunning;
    private int isDead;
    [SerializeField] int maxHealth=100;
    private int currentHealth;
    private bool isPlayerDead=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        idRunning = Animator.StringToHash("isRunning");
        isDead = Animator.StringToHash("isDead");
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if(horizontalInput!=0 &&isPlayerDead==false)
        {
           Move(horizontalInput);    
        }
        else
        {
            anim.SetBool(idRunning, false);
        }
        if(isGround&&Input.GetKeyDown(KeyCode.Space)&&isPlayerDead==false)
        {
            Jump();
        }
    }
    private void Move(float dir)
    {
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
        if((dir>0 && !facingRight)||(dir< 0 &&facingRight))
        {
            Flip();
        }
        anim.SetBool(idRunning, true);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumFore);

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;// 1->-1 /// -1 --->1
        transform.localScale = scale;
    }

    public void TakeDamage(int damage, Vector2 force, GameObject instigator)
    {
        if(isPlayerDead) return;
        currentHealth -= damage;
        Debug.Log("Player Health" + currentHealth);
        if(currentHealth < 0)
        {
            isPlayerDead = true;
            currentHealth=0;
            anim.SetTrigger(isDead);
            //Gamemanger da chet
        }
   
    }
}
