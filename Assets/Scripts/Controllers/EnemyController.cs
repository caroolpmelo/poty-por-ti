using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private SpriteRenderer sp;

    // enemy movement values
    private float enemySpeed = 1.0f;
    private Vector3 enemySpawnPoint;

    // bullet values
    private int bulletSpeed = 400;

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
        // TODO: change enemy sprite when it receives damage
        sp = GetComponent<SpriteRenderer>();

        enemySpawnPoint = new Vector3(10.0f, transform.position.y);
        transform.position = enemySpawnPoint;

        StartCoroutine(ShootCoroutine());
    }

    private void FixedUpdate()
    {
        StartCoroutine(MoveEnemyCoroutine());
    }

    private IEnumerator MoveEnemyCoroutine()
    {
        yield return new WaitForSeconds(1.0f);
        enemyRb.velocity = Vector3.left * enemySpeed;
    }

    private IEnumerator ShootCoroutine()
    {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        Instantiate(
            bullet,
            new Vector3(
                transform.position.x - 1.0f,
                transform.position.y
            ),
            transform.rotation
        );

        // go always to left x axis
        bulletRb.AddForce(transform.right * -1 * bulletSpeed);

        yield return new WaitForSeconds(2.0f); // wait 2s to shoot
        //yield return null;
    }
}
