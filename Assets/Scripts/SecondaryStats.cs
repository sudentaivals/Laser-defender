using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryStats : MonoBehaviour
{
    [SerializeField] public UnitSide _side = UnitSide.Enemy;
    [Header("Speed stats")]
    [SerializeField] public float _maxSpeed = 20f;
    [SerializeField] public float _minSpeed = 1f;
    [HideInInspector] public float _deltaSpeed;
    public float _speed;
    public float ActualSpeed => Mathf.Clamp(_speed + _deltaSpeed, _minSpeed, _maxSpeed);

    public Color BaseColor { get; private set; } = Color.white;


    private void Start()
    {
        BaseColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

}
