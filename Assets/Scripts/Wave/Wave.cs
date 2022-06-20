using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave
{
    public float Speed { get; private set; }

    public int NumberOfEnemies { get; private set; }

    public float SpawnSpeed { get; private set; }

    public GameObject Ship { get; private set; }

    public GameObject Path { get; private set; }

    public Wave(float speed, float spawnSpeed, int nbOfEnemies, GameObject ship, GameObject path)
    {
        Speed = speed;
        SpawnSpeed = spawnSpeed;
        NumberOfEnemies = nbOfEnemies;
        Ship = ship;
        Path = path;
    }



}
