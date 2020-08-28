using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float playerSpeed = 4.0f;

    private bool facingRight;
    private float initialY;
    private float verticalInput;
    private float horizontalInput;

    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();

        initialY = -1.93f;
        transform.position = new Vector3(-7f, initialY);
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        MovePlayer();
        OnKeyPressed();
    }

    private void MovePlayer()
    {
        // right
        if (horizontalInput > 0.0f)
        {
            rb.velocity = Vector3.right * playerSpeed;
            // transform.position += Vector3.right * playerSpeed * Time.deltaTime;
        }

        // left
        if (horizontalInput < 0.0f)
        {
            facingRight = false;
            rb.velocity = Vector3.left * playerSpeed;
            // transform.position += Vector3.left * playerSpeed * Time.deltaTime;
        }

        // jump
        if (verticalInput > 0.0f && transform.position.y <= initialY + 2.5f)
        {
            rb.velocity = Vector3.up * playerSpeed;
            // transform.position += Vector3.up * playerSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        { 
            Debug.Log("funcionou player");
        }
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
        Instantiate(
            bullet,
            new Vector3(
                transform.position.x * -1 + 3.0f,
                transform.position.y
            ),
            transform.rotation
        );

        yield return new WaitForSecondsRealtime(2); // TODO: not working
    }
}
