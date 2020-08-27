using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float velocity = 5f;

    private Rigidbody2D rb;

    public enum Letter
    {
        A,
        W,
        S,
        D
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // set bullet to destroy itself after 2s
        //Destroy(gameObject, 2.0f);

        // push bullet to direction it's facing
    }

    //private void Update()
    //{
    //    if (rb.velocity == 0)
    //    {
    //        rb.AddForce(transform.forward * 400);
    //    }
    //    //OnKeyPressed();
    //}

    private void FixedUpdate()
    {
        //if (rb.velocity.magnitude < 0.01)
        //{
            rb.AddForce(transform.forward * 400);
            //transform.Translate(1f * velocity * Time.deltaTime);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("funcionou bala");
        }
    }
}
