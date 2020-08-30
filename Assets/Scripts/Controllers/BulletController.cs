using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2.0f); // destroy itself after seconds
    }

    private void FixedUpdate()
    {
        IsOutOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignores physical collision
        if (
            collision.gameObject.tag == "Wall" ||
            collision.gameObject.tag == "Player" ||
            collision.gameObject.tag == "Enemy"
        )
            Destroy(gameObject);
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
    }

    private void IsOutOfBounds()
    {
        // is out of screen bounds
        if (transform.position.x <= -10.0f || transform.position.x >= 10.0f)
            Destroy(gameObject);
    }
}
