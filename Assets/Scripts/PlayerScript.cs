using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player movement")]
    [SerializeField] float _moveSpeed = 1.0f;
    [SerializeField] float _delayBeforeLoadingScene = 2.0f;
    private float PlayerWidthInUnits => (float)_spriteRenderer.sprite.texture.width / _spriteRenderer.sprite.pixelsPerUnit;
    private float PlayerHeightInUnits => (float)_spriteRenderer.sprite.texture.height / _spriteRenderer.sprite.pixelsPerUnit;


    private float _xMin;
    private float _xMax;

    private float _yMin;
    private float _yMax;

    private SpriteRenderer _spriteRenderer;

    private SkillManager _skillManager;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _skillManager = GetComponent<SkillManager>();
        SetMovingBoundaries();
    }

    
    private void SetMovingBoundaries()
    {
        var gameCamera = Camera.main;
        _xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        _xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        _yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y;
        _yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    void Update()
    {
        MoveHorizontal();
        MoveVertical();
        Fire();
    }

    private void MoveHorizontal()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, _xMin + PlayerWidthInUnits / 2, _xMax - PlayerWidthInUnits / 2);
        transform.position = new Vector3(newXPos, transform.position.y);
    }

    private void MoveVertical()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, _yMin + PlayerHeightInUnits / 2, _yMax - PlayerHeightInUnits / 2);
        transform.position = new Vector3(transform.position.x, newYPos);
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1"))
        {
            foreach (var skill in _skillManager.SkillList)
            {
                skill.TryUseSkill();
            }
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<SceneChangerScript>()?.LoadSceneWithDelay("GameOverMenu", _delayBeforeLoadingScene);

        //MusicPlayer.Instance.StopForConcreteTime(_delayBeforeLoadingScene);
    }


}
