using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour {

    public Text scoreDisplay;

    // Use this for initialization
    void Start () {
        GameObject crossScenesVariables = GameObject.Find("CrossScenesVariables");
        int best = PlayerPrefs.GetInt("Best");
        int score = crossScenesVariables.GetComponent<CrossScenesVariables>().score;
        scoreDisplay.text = string.Format("Score: {0}\nBest Score: {1}", score, best);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
