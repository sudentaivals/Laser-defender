using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSript : MonoBehaviour
{
    [SerializeField] Vector2 _velocity = new Vector2(0, 5);
    [SerializeField] float _rotationPerSec = 0f;

    private Rigidbody2D _rigidBody2D;
    private void LoadVariables()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    

    void Start()
    {
        LoadVariables();
        _rigidBody2D.velocity = _velocity;
    }

    // Update is called once per frame
    void Update()
    {
        RotateProjectile();
    }

    private void RotateProjectile()
    {
        transform.Rotate(0f, 0f, _rotationPerSec * Time.deltaTime);
    }
}
