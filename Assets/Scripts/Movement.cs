using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameManager manager; 
    [SerializeField] private float inputHorizontal;

    [SerializeField] private float normalSpeed = 10f;
    [SerializeField] private float runSpeed = 15f;
    [SerializeField] private float _speed;

    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 5f;

    [SerializeField] private LayerMask LadderLayer;

    [SerializeField] private bool isOnLadder;
    [SerializeField] private bool isAbleToJump;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        Vector3 pos = transform.position;
        pos.y = 0;
        pos.x = 0;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for climb
        if (collision.CompareTag("Walls"))
        {
            isAbleToJump = true;
        }
        // Collect Coins
        if (collision.CompareTag("Coins"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
            audioManager.PlayAudio("Coin");
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Death by obstacles
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Vector3 pos = transform.position;
            pos.y = 0;
            pos.x = 0;
            transform.position = pos;
            transform.localScale = Vector3.one;
            manager.DecreaseLives();
            audioManager.PlayAudio("Death");
        }
    }

    private void Update()
    {
        rb.gravityScale = 1f;
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        // Fall
        Vector3 pos = transform.position;
        if (pos.y <= -8.5)
        {
            pos.x = 0;
            pos.y = 0;
            transform.position = pos;
            manager.DecreaseLives();
            audioManager.PlayAudio("Fall");
        }

        // Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = runSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            _speed = normalSpeed;
            animator.SetBool("Running", false);
        }

        // Climb || Jump
        if (rb.IsTouchingLayers(LadderLayer))
        {
            if (!isOnLadder)
            {
                rb.gravityScale = 0;

                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    Vector3 pos1 = transform.position;
                    pos1.y += 5f * Time.deltaTime;
                    transform.position = pos1;
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    Vector3 pos2 = transform.position;
                    pos2.y -= 5f * Time.deltaTime;
                    transform.position = pos2;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) && isAbleToJump == true || Input.GetKeyDown(KeyCode.UpArrow) && isAbleToJump == true)
        {
            rb.gravityScale = 1f;
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            isAbleToJump = false;
        }

        // Move
        if (inputHorizontal > 0)
        {
            transform.localScale = Vector3.one;
        }
        if (inputHorizontal < 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (inputHorizontal != 0)
        {
            animator.SetBool("Walking", true);
            audioManager.PlayAudio("Walk");
        }
        else
        {
            animator.SetBool("Walking", false);
            audioManager.StopAudio("Walk");
        }
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.right * inputHorizontal * _speed * Time.deltaTime;
    }
}
