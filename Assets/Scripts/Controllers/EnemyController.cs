using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
    }

    private void FixedUpdate()
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

        yield return new WaitForSeconds(2.0f); // wait 2s to shoot
        //yield return null;
    }
}
