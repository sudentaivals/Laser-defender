using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Skill shell")]
public class SpawnSkillShell : SkillShell
{
    [Header("Spawn stats")]
    [SerializeField] GameObject _spawnObject;
    [SerializeField] List<Vector2> _offSetPositions;

    public GameObject SpawnObject => _spawnObject;

    public Action<GameObject, Vector2> GetSpawnAction()
    {
        return (spawnObject, spawnPosition) =>
        {
            foreach (var offSetPos in _offSetPositions)
            {
                Instantiate(spawnObject, spawnPosition + offSetPos, Quaternion.identity);
            }
        };
    }

}
