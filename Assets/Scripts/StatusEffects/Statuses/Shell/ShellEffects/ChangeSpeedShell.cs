using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Change speed Effect)")]
public class ChangeSpeedShell : StatusEffectShell
{
    [SerializeField] float _deltaSpeed;
    public override BaseStatusEffect GetStatusEffect(GameObject owner)
    {
        return new ChangeSpeed(owner, Duration, _deltaSpeed);
    }
}
