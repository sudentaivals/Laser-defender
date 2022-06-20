using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUpdater : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    private PlayerScript _playerScript;
    private void Start()
    {
        _playerScript = FindObjectOfType<PlayerScript>();
    }
    private void Update()
    {
        _text.text = _playerScript == null ? "0" : _playerScript.GetComponent<HealthSystem>().CurrentHealth.ToString();
    }
}
