using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int totalEnemies = 5;
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] Text scoreText;
    [SerializeField] AudioClip audioClip;

    int enemyCount = 1; // we will always have at least one enemy spawning at start

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = enemyCount.ToString();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(enemyCount < totalEnemies)
        {
            GetComponent<AudioSource>().PlayOneShot(audioClip, 0.6f);
            var enemy = Instantiate<GameObject>(enemyPrefab, transform.position, Quaternion.identity);
            var enemyList = GameObject.FindGameObjectWithTag("Enemy List");
            enemy.transform.SetParent(enemyList.transform);
            enemyCount++;
            scoreText.text = enemyCount.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
