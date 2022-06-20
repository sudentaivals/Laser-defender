using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        ScoreSystem.Instance.ResetScore();
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverMenu");

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSceneWithDelay(string sceneName, float delaySecs)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName, delaySecs));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName, float delaySecs)
    {
        yield return new WaitForSeconds(delaySecs);
        SceneManager.LoadScene(sceneName);
    }
}
