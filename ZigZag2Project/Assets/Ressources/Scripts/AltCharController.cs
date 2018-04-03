using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCharController : MonoBehaviour {

    private Rigidbody rb;
    private bool facingRight = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeDir();
        }
	}

    private void changeDir()
    {
        facingRight = !facingRight;

        if (facingRight)        
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else       
            transform.rotation = Quaternion.Euler(0, -45, 0);        
    }
}
