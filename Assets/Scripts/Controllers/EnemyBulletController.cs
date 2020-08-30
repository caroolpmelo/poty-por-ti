using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : BulletController
{
    private SpriteRenderer sp;

    // score sprites
    [SerializeField]
    private List<Sprite> fireSprites = new List<Sprite>(2);

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        sp.sprite = fireSprites[Random.Range(0, fireSprites.Count)]; // set sprites
        sp.transform.localScale = new Vector3(0.4f, 0.4f); // scale obj (it's big)
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject); // destroy bullet
            // TODO: game over screen
            Debug.Log("PERDEU atingida por fogo");
        }
    }
}
