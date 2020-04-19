using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    bool ended = false;

    // Update is called once per frame
    void Update()
    {
        if(!ended && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            int pos = Random.Range(0, 4);
            if (pos == 0)
            {
                // top
                randX = Random.Range(-5.5f, 6.5f);
                randY = 4.5f;
            }
            else if (pos == 1)
            {
                // left
                randX = -5.5f;
                randY = Random.Range(-4.5f, 4.5f);
            }
            else if (pos == 2)
            {
                // right
                randX = 6.5f;
                randY = Random.Range(-4.5f, 4.5f);
            }
            else if (pos == 3)
            {
                // bottom
                randX = Random.Range(-5.5f, 6.5f);
                randY = -4.5f;
            }
            whereToSpawn = new Vector2(randX, randY);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }    
    }

    public void EndSpawning()
    {
        ended = true;
    }
}
