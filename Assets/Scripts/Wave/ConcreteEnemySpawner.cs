using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteEnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> _waves;
    [SerializeField] int _startingWaveIndex = 0;
    [SerializeField] bool _isLooping;


    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = _startingWaveIndex; i < _waves.Count; i++)
        {
            var currentWave = _waves[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
        if(_isLooping) StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            var enemy = Instantiate(waveConfig.Enemy, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyPathingScript>().SetConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    public void StopSpawningEnemies()
    {
        StopAllCoroutines();
    }



}
