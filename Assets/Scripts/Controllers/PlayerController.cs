using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private SpriteRenderer sp;

    // player movement values
    private float initialY;
    private bool facingRight;
    private float jumpHeight = 0.4f;
    private float playerSpeed = 4.0f;

    // bullet values
    private int bulletSpeed = 400;

    // inputs
    private float jumpInput;
    private float verticalInput;
    private float horizontalInput;

    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        facingRight = true;
        playerRb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        //initialY = -1.93f;
        //transform.position = new Vector3(-7f, initialY);
    }

    private void Update()
    {
        jumpInput = Input.GetAxis("Jump");
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FlipPlayerSpriteX();
        OnKeyPressed();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("PERDEU atingida por inimigo");
        }
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("PERDEU atingida por fogo");
        }
    }

    private void MovePlayer()
    {
        // right
        if (horizontalInput > 0.0f)
        {
            if (!facingRight)
                facingRight = true;
            playerRb.velocity = Vector3.right * playerSpeed;
        }

        // left
        if (horizontalInput < 0.0f)
        {
            if (facingRight)
                facingRight = false;
            playerRb.velocity = Vector3.left * playerSpeed;
        }

        // jump
        if (jumpInput > 0.0f && transform.position.y <= jumpHeight)
        {
            playerRb.velocity = Vector3.up * playerSpeed;
        }
    }

    private void FlipPlayerSpriteX()
    {
        if (facingRight && sp.flipX)
            sp.flipX = false;
        if (!facingRight && !sp.flipX)
            sp.flipX = true;
    }

    private void OnKeyPressed()
    {
        if (
            Input.GetKeyDown(KeyCode.Z) ||
            Input.GetKeyDown(KeyCode.X) ||
            Input.GetKeyDown(KeyCode.C) ||
            Input.GetKeyDown(KeyCode.V)
        )
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    private IEnumerator ShootCoroutine()
    {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        Instantiate(
            bullet,
            new Vector3(
                transform.position.x + 1.0f,
                transform.position.y
            ),
            transform.rotation
        );

        if (facingRight)
            // go to right x axis
            bulletRb.AddForce(transform.right * bulletSpeed);
        if (!facingRight)
            // go to left x axis
            bulletRb.AddForce(transform.right * -1 * bulletSpeed);

        yield return new WaitForSecondsRealtime(2.0f); // TODO: not working
    }


}

        













