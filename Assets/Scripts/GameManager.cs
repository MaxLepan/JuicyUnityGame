using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] TextMeshPro highScoreText;
    [SerializeField] float timeBeforeRestart = 2;
    [SerializeField] float slowness = 10;
    [SerializeField] AudioSource audioSource;

    bool isGameEnded = false;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("high_score");
        highScoreText.SetText(highScore.ToString("0"));
    }

    private void Update()
    {
        if (isGameEnded == false)
        {
            float score = Time.timeSinceLevelLoad * 10f;
            scoreText.SetText(score.ToString("0"));
            if (score > float.Parse(highScoreText.text))
            {
                highScoreText.SetText(score.ToString("0"));
            }
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
        PlayerPrefs.SetInt("high_score", int.Parse(highScoreText.text));

        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        audioSource.pitch = audioSource.pitch / slowness * 5;

        yield return new WaitForSeconds(timeBeforeRestart / slowness);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
    }
}
