using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField] private float speedY = 3f;
    private float imgWidht;

    private void Start()
    {
        imgWidht = GetComponent<BoxCollider2D>().size.x;
    }

    private void Update() 
    {
        transform.position -= Vector3.right * speedY * Time.deltaTime;

        if(transform.position.x < -imgWidht)
        {
            transform.position = new Vector3(imgWidht, transform.position.y);
        }
    }
}
