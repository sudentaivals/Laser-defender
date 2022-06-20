using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffectShell : ScriptableObject
{

    [SerializeField] float _durationSecs;
    [HideInInspector] public float Duration => _durationSecs;

    public abstract BaseStatusEffect GetStatusEffect(GameObject owner);

}
