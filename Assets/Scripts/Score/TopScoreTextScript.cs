using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopScoreTextScript : MonoBehaviour
{
    [SerializeField] TopScore _score;
    [SerializeField] TextMeshProUGUI _text;
    void Start()
    {
        _score.UpdateScore(ScoreSystem.Instance.CurrentScore);
        _text.text = _score.Score.ToString();
    }


}
