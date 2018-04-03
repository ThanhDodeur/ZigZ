using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int score;
    public bool gameStarted;
    public Text scoreText;
    public Text bestScore;

    private void Awake()
    {
        bestScore.text = "Best: " + GetBest().ToString();       
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadGenerator>().begingGeneration();
    }

    public void EndGame()
    {
        GameObject crossScenesVariables = GameObject.Find("CrossScenesVariables");
        crossScenesVariables.GetComponent<CrossScenesVariables>().score = 0 + score;
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
        scoreText.text = "Score: " + score.ToString();
        if(score > GetBest())
        {
            PlayerPrefs.SetInt("Best", score);
            bestScore.text = string.Format("Best: {0}", score);
        }
        
    }

    public int GetBest()
    {
        return 0 + PlayerPrefs.GetInt("Best");
    }
        
}
