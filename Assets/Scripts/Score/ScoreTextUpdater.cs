using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextUpdater : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _text;
    void Start()
    {
        _text.text = ScoreSystem.Instance.CurrentScore.ToString();
    }

    public void SetScore(int score)
    {
        _text.text = score.ToString();
    }
}

