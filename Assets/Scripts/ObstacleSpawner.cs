using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    public void InstantiateObstacle()
    {
        GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
        obstacle.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    private void Start() {
        InstantiateObstacle();
    }

}
