using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour {

    public GameObject small;
    public GameObject medium;
    public GameObject big;
    

    public Vector3 lastPos;
    public float cubeL = 0.707f;
    public float growth = 1.0f; // permet a la chance d'avoir des bonnes gemmes de grandir avec le temps.

    public void begingGeneration()
    {
        InvokeRepeating("SpawnRoad", 1f, 0.5f);
    }

    public void SpawnRoad()
    {
        Vector3 spawnPos = Vector3.zero;

        float chance = Random.Range(0, 100);

        // RNG pour la position de la case.
        if(chance < 42)
        {
            spawnPos = new Vector3(lastPos.x + cubeL, lastPos.y, lastPos.z + cubeL);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - cubeL, lastPos.y, lastPos.z + cubeL);
        }

        // RNG pour les valeurs des gemmes.
        float randScore = Random.Range(0, 1000 + growth);
        float bigChance = 10.0f + growth;
        float mediumChance = 300.0f + growth;

        if(randScore < bigChance)
        {
            GameObject newRoad = Instantiate(big, spawnPos, Quaternion.Euler(0, 45, 0));
            lastPos = newRoad.transform.position;
        }
        else if (randScore < mediumChance)
        {
            GameObject newRoad = Instantiate(medium, spawnPos, Quaternion.Euler(0, 45, 0));
            lastPos = newRoad.transform.position;
        }
        else if (randScore >= mediumChance)
        {
            GameObject newRoad = Instantiate(small, spawnPos, Quaternion.Euler(0, 45, 0));
            lastPos = newRoad.transform.position;
        }

        growth++;
                
    }

}
