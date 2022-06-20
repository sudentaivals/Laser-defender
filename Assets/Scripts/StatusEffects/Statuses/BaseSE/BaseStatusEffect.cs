using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStatusEffect
{
    public GameObject GameObject { get; private set; }

    public float Duration => _durationSecs;

    private float _durationSecs;

    public BaseStatusEffect(GameObject owner, float duration)
    {
        _durationSecs = duration;
        GameObject = owner;
    }

    public abstract void ActionOnStart();

    public abstract void ActionOnDestroy();

    protected abstract void ActionOnUpdate(float deltaTime);

    public void Update(float deltaTime)
    {
        ActionOnUpdate(deltaTime);
        _durationSecs -= deltaTime;
    }

}

