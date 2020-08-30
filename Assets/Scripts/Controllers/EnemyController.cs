using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyManager enemyManager = EnemyManager.Instance;

    private Rigidbody2D enemyRb;
    private SpriteRenderer sp;

    // enemy movement values
    private float enemySpeed = 0.8f;
    private Vector3 enemySpawnPoint;

    // bullet values
    private float bulletSpeed = 0.8f;

    // enemy colored states
    [SerializeField]
    private bool isBlack;
    [SerializeField]
    private bool isBlue;
    [SerializeField]
    private bool isRed;
    [SerializeField]
    private bool isWhite;
    [SerializeField]
    private bool isYellow;

    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        enemySpawnPoint = new Vector3(10.0f, transform.position.y);
        transform.position = enemySpawnPoint;

        StartCoroutine(ShootCoroutine());
    }

    private void FixedUpdate()
    {
        StartCoroutine(MoveEnemyCoroutine());
        IsOutOfBounds();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ignores wall and if it's blue just go till the end
        if (collision.gameObject.tag == "Wall" || isBlue)
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
    }

    private IEnumerator MoveEnemyCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        enemyRb.velocity = Vector3.left * enemySpeed;
        enemyRb.rotation = 0;
    }

    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (!isBlue)
            {
                yield return new WaitForSeconds(2.0f); // wait 2s to shoot
            
                GameObject newBullet = Instantiate(
                    bullet,
                    new Vector3(
                        transform.position.x - 2.0f,
                        transform.position.y
                    ),
                    transform.rotation
                );
            
                Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
                // go always to left x axis
                bulletRb.AddForce(transform.right * -1 * bulletSpeed * Time.deltaTime);
            }
        }
    }

    private void IsOutOfBounds()
    {
        // enemy is out of screen bounds
        if (transform.position.x <= -10.0f)
            Destroy(gameObject);
    }
}
