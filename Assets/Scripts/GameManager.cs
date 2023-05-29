using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;

    private void Awake() 
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }
}
