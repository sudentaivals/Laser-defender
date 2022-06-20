using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    List<BaseStatusEffect> _effects;
    void Start()
    {
        _effects = new List<BaseStatusEffect>();
    }

    public void AddNewStatusEffect(StatusEffectShell effect)
    {
        var newEffect = effect.GetStatusEffect(gameObject);
        newEffect.ActionOnStart();
        _effects.Add(newEffect);

    }

    void Update()
    {
        //update
        foreach (BaseStatusEffect effect in _effects)
        {
            effect.Update(Time.deltaTime);
            if (effect.Duration <= 0)
            {
                effect.ActionOnDestroy();
            }
        }
        //destroy
        _effects.RemoveAll(a => a.Duration <= 0);
    }
}
