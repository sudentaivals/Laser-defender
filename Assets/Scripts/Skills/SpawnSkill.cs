using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkill : MonoBehaviour
{
    private GameObject _spawnObject;

    private AudioClip _soundOnSpawn;

    private float _soundVolume;
    public string SkillName { get; private set; }

    private float _coolDown;

    private float _currentCooldown;

    private Action<GameObject, Vector2> _spawnSkillAction;

    void Start()
    {
        
    }

    void Update()
    {
        CheckCooldown();
    }

    public void SetSoundEffect(AudioClip effect, float volume)
    {
        _soundOnSpawn = effect;
        _soundVolume = volume;
    }

    public void SetName(string name)
    {
        SkillName = name;
    }

    public void SetCooldown(float cooldown)
    {
        _coolDown = cooldown;
        _currentCooldown = _coolDown;
    }

    public void SetObject(GameObject spawn)
    {
        _spawnObject = spawn;
    }

    public void SetAction(Action<GameObject, Vector2> action)
    {
        _spawnSkillAction = action;
    }

    private void CheckCooldown()
    {
        if(_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;
        }
    }
    
    public void TryUseSkill()
    {
        if(_currentCooldown <= 0)
        {
            _spawnSkillAction.Invoke(_spawnObject, gameObject.transform.position);
            AudioSource.PlayClipAtPoint(_soundOnSpawn, Camera.main.transform.position, _soundVolume);
            _currentCooldown = _coolDown;
        }
    }
}
