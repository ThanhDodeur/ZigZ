using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score;
    public bool gameStarted;
    public Text scoreText;

    public void StartGame()
    {
        gameStarted = true;
    }

    public void EndGame()
    {
        SceneManager.LoadScene("End");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartGame();
        }
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
}
