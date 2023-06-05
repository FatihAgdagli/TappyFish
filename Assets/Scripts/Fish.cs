using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private float speedY = 9f;
    [SerializeField] private Score scoreScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Sprite deadFishSpride;
    [SerializeField] private AudioSource pointAudio;
    [SerializeField] private AudioSource swimAudio;
    [SerializeField] private AudioSource hitAudio;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private int angle;
    private int maxAngle = 45;
    private int minAngle = -20;

    private bool touchedGround;
    private void Awake()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        rigidbody2d = GetComponent<Rigidbody2D>();

        rigidbody2d.gravityScale = 0f;
    }

    private void Update() 
    {
        FishSwim();
    }

    private void FixedUpdate() 
    {
        FishRotation();
    }

    private void FishRotation()
    {
        if(!GameManager.gameStarted)
        {
            return;
        }

        if (touchedGround)
        {
            return;
        }

        if(rigidbody2d.velocity.y > 0)
        {
            angle += 4;
        }
        else if (rigidbody2d.velocity.y < 0)
        {
            angle -=2;
        }
        
        angle = Mathf.Clamp(angle, minAngle, maxAngle);


        transform.rotation = Quaternion.Euler(0,0, angle);
    }
   
   private void FishSwim()
   {
        if (GameManager.gameOver)
        {
            return;
        }



        if( Input.GetMouseButtonDown(0))
        {
            rigidbody2d.gravityScale = 4f;
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, speedY);

            gameManager.GameHasStarted();

            swimAudio.Play();
        } 
   }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Obstacles"))
        {
            if (GameManager.gameOver)
            {
                return;
            }

            pointAudio.Play();

            scoreScript.Scored();
        }
        else if(other.CompareTag("Column"))
        {
            GameOver();

            gameManager.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            if (!GameManager.gameOver)
            {
                GameOver();

                gameManager.GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        if (GameManager.gameOver)
        {
            return;
        }

        hitAudio.Play();

        touchedGround = true;

        animator.enabled = false;

        spriteRenderer.sprite = deadFishSpride;

        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
