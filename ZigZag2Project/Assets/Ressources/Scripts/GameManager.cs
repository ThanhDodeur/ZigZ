using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameStarted;

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
}
