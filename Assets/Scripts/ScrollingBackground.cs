using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float _scrollingSpeed = 1f;

    private Material _material;
    private Vector2 _offSet;
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offSet = new Vector2(0, _scrollingSpeed);
    }

    void Update()
    {
        _material.mainTextureOffset += _offSet * Time.deltaTime;
    }
}
