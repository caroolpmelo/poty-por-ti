using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private enum color
    {
        Black = 0,
        Blue = 1,
        Red = 2,
        White = 3,
        Yellow = 4
    }

    private int bulletColorIndex = 0;

    public int BulletColor
    {
        get { return this.bulletColorIndex; }

        private set
        {
            // if ()
        }
    }

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
