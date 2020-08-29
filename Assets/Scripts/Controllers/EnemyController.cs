using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // bullet values
    private int bulletSpeed = 400;

    // enemy colored sprites
    [SerializeField]
    private Sprite enemyBlackSprite;
    [SerializeField]
    private Sprite enemyBlueSprite;
    [SerializeField]
    private Sprite enemyRedSprite;
    [SerializeField]
    private Sprite enemyWhiteSprite;
    [SerializeField]
    private Sprite enemyYellowSprite;

    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
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

        yield return new WaitForSecondsRealtime(2.0f); // TODO: not working
    }
}
