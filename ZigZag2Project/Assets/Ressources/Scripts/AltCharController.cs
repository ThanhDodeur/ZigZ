using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCharController : MonoBehaviour {

    public Transform rayOrigin;

    private Rigidbody rb;
    private bool facingRight = true;
    private Animator animator;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            animator.SetTrigger("gameStarted");
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            changeDir();
        }

        RaycastHit hit;

        if(!Physics.Raycast(rayOrigin.position, -transform.up, out hit, 200))
        {
            animator.SetTrigger("noGround");
        }
        if(transform.position.y < -10)
        {
            gameManager.EndGame();
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
