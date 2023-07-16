using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBombs3 : MonoBehaviour
{
    public GameObject bomb;
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(bomb, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
