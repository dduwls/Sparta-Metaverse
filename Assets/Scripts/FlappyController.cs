using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyController : MonoBehaviour
{
    public float flapForce = 6f;
    public float velocityReductionFactor = 0.1f;
    public float forwardSpeed = 3f;
    public bool godMode = false;

    private GameManager gameManager;
    private Animator anim;
    private Rigidbody2D rb;
    private bool isFlap = false;
    private bool isDead = false;
    private float deathCooldown = 0f;

    private void Start()
    {
        gameManager = GameManager.Instance; 

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (anim == null)
        {
            Debug.LogError("Animator is NULL.");
        }
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is NULL.");
        }
    }

    private void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                // if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                // {
                //     // gameManager.Restart();
                //     SceneManager.LoadScene("MainScene");
                // }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = rb.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        rb.velocity = velocity;

        float angle = Mathf.Clamp(rb.velocity.y * 10f, -90, 90);

        transform.rotation = Quaternion.Euler(0, 0, angle); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        anim.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
