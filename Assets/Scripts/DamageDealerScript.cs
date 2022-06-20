using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerScript : MonoBehaviour
{
    [SerializeField] int _damage = 100;
    [SerializeField] List<StatusEffectShell> _effectsOnHit;

    public List<StatusEffectShell> EffectsOnHit => _effectsOnHit;

    public int Damage => _damage;

    public void Hit()
    {
        if(gameObject.GetComponent<HealthSystem>() != null)
        {
            gameObject.GetComponent<HealthSystem>().GetDamage(gameObject.GetComponent<HealthSystem>().CurrentHealth);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
