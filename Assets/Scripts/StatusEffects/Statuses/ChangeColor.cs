using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class ChangeColor : BaseStatusEffect
{
    private Color _newColor;

    public ChangeColor(GameObject owner, float duration, Color color) : base(owner, duration)
    {
        _newColor = color;
    }

    public override void ActionOnDestroy()
    {
        GameObject.GetComponent<SpriteRenderer>().color = GameObject.GetComponent<SecondaryStats>().BaseColor;
    }

    public override void ActionOnStart()
    {
        return;
    }

    protected override void ActionOnUpdate(float deltaTime)
    {
        GameObject.GetComponent<SpriteRenderer>().color = _newColor;
    }
}
