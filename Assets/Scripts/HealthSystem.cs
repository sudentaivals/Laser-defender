using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] GameObject _explosionOnDeathVFX;
    [SerializeField] AudioClip _soundOnDeath;
    [SerializeField] [Range(0f, 1f)] float _deathSoundVolume = 0.75f;

    private SecondaryStats _stats;

    public int CurrentHealth => _health;

    private void Start()
    {
        _stats = GetComponent<SecondaryStats>();
    }
    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            SpawnVFXOnDeath();
            PlaySoundEffectOnDeath();
            gameObject.GetComponent<ScoreScript>()?.GenerateScore();
            Destroy(gameObject);
        }
    }

    private void PlaySoundEffectOnDeath()
    {
        if (_soundOnDeath != null)
        {
            AudioSource.PlayClipAtPoint(_soundOnDeath, Camera.main.transform.position, _deathSoundVolume);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageDealerScript>() == null) return;
        var damageObjectSecondStats = collision.gameObject.GetComponent<SecondaryStats>();
        if (_stats._side != damageObjectSecondStats._side)
        {
            DamageDealerScript damageDealer = collision.GetComponent<DamageDealerScript>();
            ApplyStatusEffects(damageDealer);
            GetDamage(damageDealer.Damage);
            damageDealer.Hit();
        }
    }

    private void ApplyStatusEffects(DamageDealerScript damageDealer)
    {
        if (damageDealer.EffectsOnHit == null) return;
        bool tryGetComponent = TryGetComponent<StatusEffectManager>(out StatusEffectManager healthObjecteffectManager);
        if (tryGetComponent)
        {
            foreach (var effect in damageDealer.EffectsOnHit)
            {
                healthObjecteffectManager.AddNewStatusEffect(effect);
            }
        }
    }

    private void SpawnVFXOnDeath()
    {
        if (_explosionOnDeathVFX != null)
        {
            var particleEmmiter = Instantiate(_explosionOnDeathVFX, transform.position, Quaternion.identity);
            Destroy(particleEmmiter, 1f);
        }
    }

    private void OnDisable()
    {
    }
}
