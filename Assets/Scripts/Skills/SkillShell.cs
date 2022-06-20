using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillShell : ScriptableObject
{
    [Header("Base stats")]
    [SerializeField] float _cooldownSec;
    [SerializeField] string _name;
    [SerializeField] AudioClip _soundOnUsage;
    [SerializeField] [Range(0f, 1f)] float _soundOnUsageVolume;

    public AudioClip SoundOnUsage => _soundOnUsage;

    public float SoundVolume => _soundOnUsageVolume;
    public float Cooldown => _cooldownSec;
    public string SkillName => _name;
}
