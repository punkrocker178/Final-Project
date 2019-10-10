﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform agentsPrefab;
    public Transform spawnPoint;
    public Text waveCountdownText;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave Incoming" + waveIndex);
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnAgent();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnAgent()
    {
        Instantiate(agentsPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}