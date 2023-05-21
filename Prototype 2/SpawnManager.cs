using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrejabs;
    public GameObject[] sideAnimalPrejabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnSidePosBottomZ = 1;
    private float spawnSidePosTopZ = 14;
    private float spawnSideRangeX = 25;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal ()
    {
            int animalIndex = Random.Range(0, animalPrejabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalSideIndex = Random.Range(0, sideAnimalPrejabs.Length);
            Vector3 spawnPosSide = new Vector3(-spawnSideRangeX, 0, (Random.Range(spawnSidePosBottomZ, spawnSidePosTopZ)));

// I tried combining side spawner into main spawner, but this doesnt work. New Prefabs will need to be made for the animals
// Because the top animal prefabs have a "move forward" script to them that has them move from top to bottom, and they're orientated a different way. 

            Instantiate(animalPrejabs[animalIndex], spawnPos, animalPrejabs[animalIndex].transform.rotation);
            Instantiate(sideAnimalPrejabs[animalSideIndex], spawnPosSide, sideAnimalPrejabs[animalSideIndex].transform.rotation);
    }
}
