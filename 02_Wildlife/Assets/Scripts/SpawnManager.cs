using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
   
    private int animalIndex;
    private float spawnRangeX = 14f;
    private float spawnPosZ;

    [SerializeField, Range(2, 5)]
    private float startDelay = 2f;
    
    [SerializeField, Range(0.1f, 3f)]
    private float spawnInterval = 0.1f;
    private void Start()
    {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandomAnimal",
            startDelay,spawnInterval);
    }
    
    private void SpawnRandomAnimal()
    {
        //Generar la posición donde va a aparecer el próximo enemigo
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);

        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex],
            spawnPos,
            enemies[animalIndex].transform.rotation);

    }
    
    
    
    
}
