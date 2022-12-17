using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyInstance;
    public int numberToSpawn = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check for enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length < numberToSpawn)
        {
            Instantiate(enemyInstance, gameObject.transform.position, Quaternion.identity);
        }
    }
}
