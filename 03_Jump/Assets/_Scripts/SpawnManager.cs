using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    private float startDelay = 2;
    private float repeatRate = 2;



    private PlayerController _playerController;
    void Start()
    {
        spawnPos = this.transform.position; //(30,0,0)
        InvokeRepeating("SpawnObstacle", 
            startDelay, repeatRate);
        _playerController = GameObject.Find("Player")
            .GetComponent<PlayerController>();
    }

    void SpawnObstacle()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstaclePrefab =
                obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos,
                obstaclePrefab.transform.rotation);
        }
    }
    
}
