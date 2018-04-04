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
    private GameObject crossScenesVariables;

    private void Awake()
    {
        crossScenesVariables = GameObject.Find("CrossScenesVariables");
        bestScore.text = "Best: " + GetBest().ToString();       
    }

    public void StartGame()
    {
        gameStarted = true;
        FindObjectOfType<RoadGenerator>().begingGeneration();
    }

    public void EndGame()
    {       
        // null pointer si le jeu est lance hors de l'ecran titre car crossScenesVariables est instancie dans la scene precedente.
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
