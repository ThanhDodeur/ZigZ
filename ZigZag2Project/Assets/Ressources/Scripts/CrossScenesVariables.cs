using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScenesVariables : MonoBehaviour {

    public int score;
    public int best;
    
    private void Awake()
    {
        // conserve l'objet entre chaque scenes.
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
