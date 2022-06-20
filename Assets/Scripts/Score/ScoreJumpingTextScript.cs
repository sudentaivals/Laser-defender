using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreJumpingTextScript : MonoBehaviour
{
    [HideInInspector]public int Score { get; set; }
    [SerializeField] float startSpeed = 6f;
    [SerializeField] float _lifeTimeSec = 3f;

    private Vector2 _velocity;

    private Vector2 _gravityVector;
    void Start()
    {
        CalculateStartVelocity();
        _gravityVector = Physics2D.gravity;
        GetComponent<TextMeshPro>().text = "+" + Score.ToString();
    }

    private void CalculateStartVelocity()
    {
        float angleRad;
        if(UnityEngine.Random.Range(0, 2) == 0)
        {
            angleRad = Mathf.Deg2Rad * UnityEngine.Random.Range(30, 76);
        }
        else
        {
            angleRad = Mathf.Deg2Rad * UnityEngine.Random.Range(105, 151);
        }
        _velocity = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * startSpeed;
    }

    void Update()
    {
        var newDeltaPosition = _velocity * Time.deltaTime;
        gameObject.transform.position = gameObject.transform.position + (Vector3)newDeltaPosition;
        _velocity += _gravityVector * Time.deltaTime;
        _lifeTimeSec -= Time.deltaTime;
        if (_lifeTimeSec <= 0)
        {
            Destroy(gameObject);
        }
    }
}
