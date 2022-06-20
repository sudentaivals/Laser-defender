using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParametersScript : MonoBehaviour
{
    [Range(0f, 1f)][SerializeField] float _soundVolume = 1f;

    public float SoundVolume => _soundVolume;
}
