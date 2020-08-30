using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private SpriteRenderer sp;

    // player movement values
    private bool facingRight;
    private float jumpHeight = 0.4f;
    private float playerSpeed = 4.0f;

    // bullet values
    private float bulletSpeed = 0.8f;

    // inputs
    private float jumpInput;
    private float fire1Input;
    private float fire2Input;
    private float fire3Input;
    private float fire4Input;
    private float horizontalInput;

    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        facingRight = true;
        sp = GetComponent<SpriteRenderer>();
        playerRb = GetComponent<Rigidbody2D>();
        //transform.position = new Vector3(-7f, initialY);
    }

    private void Update()
    {
        jumpInput = Input.GetAxis("Jump");
        fire1Input = Input.GetAxis("Fire1");
        fire1Input = Input.GetAxis("Fire2");
        fire1Input = Input.GetAxis("Fire3");
        fire1Input = Input.GetAxis("Fire4");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FlipPlayerSpriteX();

        OnShoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("PERDEU atingida por inimigo");
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

    private void OnShoot()
    {
        if (
            fire1Input != 0 ||
            fire2Input != 0 ||
            fire3Input != 0 ||
            fire4Input != 0
        )
            StartCoroutine(OnShootCoroutine());
    }

    private IEnumerator OnShootCoroutine()
    {
        StartCoroutine(ShootCoroutine());

        yield return new WaitForSeconds(2.0f);
    }

    private IEnumerator ShootCoroutine()
    {
        // change bullet position following player orientation
        Vector3 bulletPosition;
        if (facingRight)
            bulletPosition = new Vector3(
                transform.position.x + 1.5f,
                transform.position.y
            );
        else
            bulletPosition = new Vector3(
                transform.position.x - 1.5f,
                transform.position.y
            );

        // creates bullet
        GameObject newBullet = Instantiate(
            bullet,
            bulletPosition,
            transform.rotation
        );

        // makes bullet move
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (facingRight) // go to right x axis
            bulletRb.AddForce(transform.right * bulletSpeed * Time.deltaTime);
        else // go to left x axis
            bulletRb.AddForce(transform.right * -1 * bulletSpeed * Time.deltaTime);

        yield return new WaitForSeconds(2.0f);
    }
}

        













