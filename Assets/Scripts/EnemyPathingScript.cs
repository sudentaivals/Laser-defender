using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathingScript : MonoBehaviour
{
    WaveConfig _waveConfig;
    Wave _wave;
    private List<Transform> _waypointsList;

    int _waypointIndex = 0;
    SecondaryStats _stats;

    public void SetConfig(WaveConfig config)
    {
        _waveConfig = config;
    }

    public void SetWave(Wave wave)
    {
        _wave = wave;
    }
    void Start()
    {
        _stats = GetComponent<SecondaryStats>();
        if (_waveConfig!= null) _waypointsList = _waveConfig.PathWaypoints;
        SetStartingPoint();
    }

    private void SetStartingPoint()
    {
        if (_waypointsList == null) return;
        transform.position = _waypointsList[_waypointIndex].position;
        _waypointIndex++;
    }

    public void GenerateWaypoints(Transform source)
    {
        if (source == null) return;
        _waypointsList = new List<Transform>();
        foreach (var item in source)
        {
            var itemTransform = item as Transform;
            _waypointsList.Add(itemTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_waypointsList == null) return;
        if (_waypointIndex < _waypointsList.Count)
        {
            transform.position = Vector2.MoveTowards(transform.position, _waypointsList[_waypointIndex].position, _stats.ActualSpeed * Time.deltaTime);
            if (transform.position == _waypointsList[_waypointIndex].position)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
