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
    [SerializeField] Text countdownText;
    [SerializeField] GameObject countdownPanel;
    [SerializeField] AudioClip audioClip;
    [SerializeField] float timeLeft = 5.0f;
    [SerializeField] bool startGame = false;
    int enemyCount = 1; // we will always have at least one enemy spawning at start

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = enemyCount.ToString();
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        countdownText.text = timeLeft.ToString("F0");
        if(timeLeft <= 0.1) {
            Destroy(countdownText);
            Destroy(countdownPanel);
            startGame = true;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemyCount < totalEnemies)
        {
            GetComponent<AudioSource>().PlayOneShot(audioClip, 0.6f);
            if(startGame)
            {
                var enemy = Instantiate<GameObject>(enemyPrefab, transform.position, Quaternion.identity);
                var enemyList = GameObject.FindGameObjectWithTag("Enemy List");
                enemy.transform.SetParent(enemyList.transform);
                enemyCount++;
                scoreText.text = enemyCount.ToString();
            }
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
