using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCharController : MonoBehaviour {

    public Transform rayOrigin;
    public GameObject gemPopEffect;

    public AudioSource smallCoinSound;
    public AudioSource mediumCoinSound;
    public AudioSource bigCoinSound;

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
        if (Input.GetKeyDown(KeyCode.E))
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
        if (!gameManager.gameStarted)
        {
            return;
        }

        facingRight = !facingRight;

        if (facingRight)        
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else       
            transform.rotation = Quaternion.Euler(0, -45, 0);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "basicGem")
        {
            gameManager.IncreaseScore(1);
            smallCoinSound.Play();
        }
        else if (other.tag == "mediumGem")
        {
            gameManager.IncreaseScore(4);
            mediumCoinSound.Play();
        }
        else if (other.tag == "bigGem")
        {
            gameManager.IncreaseScore(10);
            bigCoinSound.Play();
        }
        
        GameObject pop = Instantiate(gemPopEffect, rayOrigin.transform.position, Quaternion.identity);
        Destroy(pop, 2);
        Destroy(other.gameObject);

    }
}
