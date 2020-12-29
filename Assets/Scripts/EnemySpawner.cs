using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int totalEnemies = 5;
    [SerializeField] float secondsBetweenSpawns = 5f;
    int enemyCount = 1; // we will always have at least one enemy spawning at start

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(enemyCount < totalEnemies)
        {
            Instantiate<GameObject>(enemyPrefab, transform.position, Quaternion.identity);
            enemyCount++;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
