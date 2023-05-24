using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float speedY = 9f;
    private int angle;
    private int maxAngle = 45;
    private int minAngle = -20;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        if( Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, speedY);
        }    

        if(rigidbody.velocity.y > 0)
        {
            angle += 4;
        }
        else if (rigidbody.velocity.y < 0)
        {
            angle -=2;
        }
        
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        transform.rotation = Quaternion.Euler(0,0, angle);

    }
}
