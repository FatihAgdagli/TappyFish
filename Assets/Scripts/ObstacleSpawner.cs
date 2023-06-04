using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnTime = 3.5f;
    private float spawnTimer = 0f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 3f;
    private float randomY;

    private void Update() 
    {
        if(GameManager.gameOver)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnTime)
        {
            InstantiateObstacle();
            spawnTimer = 0f;
        }
    }

    public void InstantiateObstacle()
    {
        randomY = UnityEngine.Random.Range(minY,maxY);
        GameObject obstacle = GameObject.Instantiate(obstaclePrefab);
        obstacle.transform.position = new Vector2(transform.position.x, transform.position.y + randomY);
    }

}
