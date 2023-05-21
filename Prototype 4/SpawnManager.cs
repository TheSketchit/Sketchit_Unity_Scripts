using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;
    private GameObject player;
    private GameManager gameManager;
    public int wavePoint = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Find the number of enemies in the scene
        enemyCount = FindObjectsOfType<Enemy>().Length;
        //If there are no enemies in the scene, spawn a new wave
        if(enemyCount == 0 && !player.GetComponent<PlayerController>().gameOver)
        {
            //Increase the wave number
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
            gameManager.UpdateScore(wavePoint);
        }

    }


    //This method spawns a number of enemies at random positions within a given range
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition("Enemy"), enemyPrefab[enemyIndex].transform.rotation);
        }
    }
    //This method spawns a powerup at a random position within a given range
    void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition("Powerup"), powerupPrefab.transform.rotation);
    }


    //This method generates a random position within a given range
    private Vector3 GenerateSpawnPosition(string tag)
    {
       // If the spawn position if for an enemy, generate a random position within the spawn range
        
       if (tag == ("Enemy"))
        {
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            float spawnPosZ = Random.Range(-spawnRange, spawnRange);
            float spawnPosY = Random.Range(18f, 21f);
            Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

            return randomPos;
        } 
        // If the spawn position if for a powerup, generate a random position within the spawn range
        else if (tag == ("Powerup"))
            {
                float spawnPosX = Random.Range(-spawnRange, spawnRange);
                float spawnPosZ = Random.Range(-spawnRange, spawnRange);
                Vector3 randomPos = new Vector3(spawnPosX, 3f, spawnPosZ);

                return randomPos;
            } 
        else
        {
            return Vector3.zero;
        }

    }

}
