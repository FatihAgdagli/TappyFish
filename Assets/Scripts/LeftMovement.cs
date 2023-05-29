using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField] private float speedY = 3f;
    private float imgWidht;
    private float obstacleWidht;

    private void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            imgWidht = GetComponent<BoxCollider2D>().size.x;
        }
        else if(gameObject.CompareTag("Column"))
        {
            obstacleWidht = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
    }

    private void Update() 
    {
        transform.position -= Vector3.right * speedY * Time.deltaTime;

        if(gameObject.CompareTag("Ground"))
        {
            if(transform.position.x < -imgWidht)
            {
                transform.position = new Vector3(imgWidht, transform.position.y);
            }
        }
            
    }
}
