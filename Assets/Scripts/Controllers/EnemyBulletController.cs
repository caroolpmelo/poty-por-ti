using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2.0f); // destroy itself after seconds
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject); // destroy bullet
        }
    }
}
