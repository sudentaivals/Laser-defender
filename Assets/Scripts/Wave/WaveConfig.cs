using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject _path;
    [SerializeField] GameObject _enemyObject;
    [SerializeField] float _spawnSpeed = 0.5f;
    [SerializeField] float _spawnRandomFactor = 0.3f;
    [SerializeField] int _numberOfEnemies = 3;
    [SerializeField] float _moveSpeedOfObjects = 8f;

    public List<Transform> PathWaypoints
    {
        get
        {
            var waypoints = new List<Transform>();
            foreach (var child in _path.transform)
            {
                var itemAsWaypoint = child as Transform;
                waypoints.Add(itemAsWaypoint);
            }
            return waypoints;
        }
    }

    public GameObject Enemy => _enemyObject;

    public float TimeBetweenSpawns => _spawnSpeed;

    public float RandomFactor => _spawnRandomFactor;

    public int NumberOfEnemies => _numberOfEnemies;

    public float MoveSpeed => _moveSpeedOfObjects;

}
