using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private float speedY = 9f;
    [SerializeField] private Score scoreScript;
    private Rigidbody2D rigidbody2d;
    private int angle;
    private int maxAngle = 45;
    private int minAngle = -20;

    private void Start() 
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if( Input.GetMouseButtonDown(0))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, speedY);
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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Obstacles"))
        {
            scoreScript.Scored();
        }
    }
}
