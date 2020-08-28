using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float velocity = 5.0f;
    private float jumpHeight = 10.0f;

    [SerializeField]
    private GameObject bullet;

    private Rigidbody2D rb;





    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        transform.position = Vector3.zero; // start player in the center
       
    }

    private void Update()
    {
        MovePlayer();
        OnKeyPressed();

    }   


    private void MovePlayer()
    {
        //float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        //Vector3 direction = new Vector3(horizontalInput, transform.position.y);

        //if (velocity != 0)
        //{
        //    // when idle, direction will be zero, so anything * 0 = 0
        //    transform.Translate(direction * velocity * Time.deltaTime);
        //}
        rb.AddForce(new Vector3(horizontalInput, transform.position.y));
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
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(
            bullet,
            new Vector3(
                transform.position.x,
                transform.position.y
            ),
            transform.rotation
        );
    }


}

        













