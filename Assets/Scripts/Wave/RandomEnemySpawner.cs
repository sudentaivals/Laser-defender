using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    [Header("Wave objects")]
    [SerializeField] List<GameObject> _shipsToSpawn;
    [SerializeField] List<GameObject> _enemyPaths;
    [Header("Wave size")]
    [SerializeField] int _minSpawns;
    [SerializeField] int _maxSpawns;
    [Header("Speed")]
    [SerializeField] float _minSpeed;
    [SerializeField] float _maxSpeed;
    [Header("Spawn interval")]
    [SerializeField] float _minSpawnInterval;
    [SerializeField] float _maxSpawnInterval;

    private int _lastShipIndex = -1;

    private int _lastPathIndex = -1;
    private Wave GenerateWave()
    {
        int nbOfEnemies = UnityEngine.Random.Range(_minSpawns, _maxSpawns);
        float speed = UnityEngine.Random.Range(_minSpeed, _maxSpeed);
        float spawnInterval = UnityEngine.Random.Range(_minSpawnInterval, _maxSpawnInterval);
        var enemy = _shipsToSpawn[GenerateShipIndex()];
        var path = _enemyPaths[GeneratePathIndex()];
        return new Wave(speed, spawnInterval, nbOfEnemies, enemy, path);
    }

    private int GenerateShipIndex()
    {
        if (_shipsToSpawn.Count == 1) return 0;
        while (true)
        {
            int index = UnityEngine.Random.Range(0, _shipsToSpawn.Count);
            if (index == _lastShipIndex)
            {
                continue;
            }
            else
            {
                _lastShipIndex = index;
                return index;
            }
        }
    }
    private int GeneratePathIndex()
    {
        if (_enemyPaths.Count == 1) return 0;
        while (true)
        {
            int index = UnityEngine.Random.Range(0, _enemyPaths.Count);
            if (index == _lastPathIndex)
            {
                continue;
            }
            else
            {
                _lastPathIndex = index;
                return index;
            }
        }
    }


    private void Start()
    {
        StartCoroutine(SpawnEnemies(GenerateWave()));
    }

    private IEnumerator SpawnEnemies(Wave waveConfig)
    {
        for (int i = 0; i < waveConfig.NumberOfEnemies; i++)
        {
            var enemy = Instantiate(waveConfig.Ship, transform.position, Quaternion.identity);
            enemy.GetComponent<EnemyPathingScript>().GenerateWaypoints(waveConfig.Path.transform);
            enemy.GetComponent<SecondaryStats>()._speed = waveConfig.Speed;
            yield return new WaitForSeconds(waveConfig.SpawnSpeed);
        }
        StartCoroutine(SpawnEnemies(GenerateWave()));
    }

    public void StopSpawningEnemies()
    {
        StopAllCoroutines();
    }

}
