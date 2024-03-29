﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    private int waveIndex = 0;

    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAlive > 0) {
            return;
        }

        // Stop spawning
        if (waveIndex == waves.Length) {
            gameManager.WinGame();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming" + waveIndex);
        PlayerStats.Rounds++;
        Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnAgent(wave.agent);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;


    }

    void SpawnAgent(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
