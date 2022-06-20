using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeSpeed : BaseStatusEffect
{
    private float _deltaSpeed;
    public ChangeSpeed(GameObject owner, float duration, float deltaSpeed) : base(owner, duration)
    {
        _deltaSpeed = deltaSpeed;
    }

    public override void ActionOnDestroy()
    {
        GameObject.GetComponent<SecondaryStats>()._deltaSpeed -= _deltaSpeed;
    }

    public override void ActionOnStart()
    {
        GameObject.GetComponent<SecondaryStats>()._deltaSpeed += _deltaSpeed;
    }

    protected override void ActionOnUpdate(float deltaTime)
    {
        return;
    }
}


