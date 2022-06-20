using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Change Color Effect)")]
public class ChangeColorShell : StatusEffectShell
{
    [SerializeField] Color _newColor;
    public override BaseStatusEffect GetStatusEffect(GameObject owner)
    {
        return new ChangeColor(owner, Duration, _newColor);
    }
}
