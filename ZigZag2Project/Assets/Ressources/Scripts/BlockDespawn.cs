using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDespawn : MonoBehaviour {

    // TODO faire le script pour despawn les cubes derrieres (z < z player) pour éviter des objets inutiles.
    public GameObject player;

    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update () {
        if (player.transform.position.z - 10 > this.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
