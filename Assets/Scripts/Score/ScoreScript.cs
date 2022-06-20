using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] int _scoreAfterDestroy;

    public void GenerateScore()
    {
        var jumpingText = Resources.Load("ScoreJumpingText") as GameObject;
        var text = Instantiate(jumpingText, gameObject.transform.position, Quaternion.identity) as GameObject;
        text.GetComponent<ScoreJumpingTextScript>().Score = _scoreAfterDestroy;
        ScoreSystem.Instance.AddScore(_scoreAfterDestroy);

    }
}
