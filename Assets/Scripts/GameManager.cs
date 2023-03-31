using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] float timeBeforeRestart = 2;
    [SerializeField] float slowness = 10;

    bool isGameEnded = false;

    private void Update()
    {
        if (isGameEnded == false)
        {
            float score = Time.timeSinceLevelLoad * 10f;
            scoreText.SetText(score.ToString("0"));
        }
    }

    public void EndGame()
    {
        if (isGameEnded != true)
        {
            isGameEnded = true;
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(timeBeforeRestart / slowness);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
    }
}
