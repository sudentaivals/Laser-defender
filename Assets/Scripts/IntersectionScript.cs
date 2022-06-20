using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionScript : MonoBehaviour
{
    [SerializeField] int _intersectDamage;

    private void OnTriggerEnter2D(Collider2D enemyColliderObject)
    {
        if (enemyColliderObject.tag != "Ship") return;
        if (enemyColliderObject.GetComponent<SecondaryStats>()._side == gameObject.GetComponent<SecondaryStats>()._side) return;
        var enemyHealth = enemyColliderObject.GetComponent<HealthSystem>();
        enemyHealth.GetDamage(_intersectDamage);
        var objectHealth = gameObject.GetComponent<HealthSystem>();
        objectHealth.GetDamage(objectHealth.CurrentHealth);
    }
}

