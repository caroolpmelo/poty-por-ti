using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Sprite enemySprite;
    [SerializeField]
    private GameObject bullet;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);

        //StartCoroutine(ShootCoroutine());
        
    }

    private IEnumerator ShootCoroutine()
    {
        Instantiate(
            bullet,
            new Vector3(
                transform.position.x + 1.0f,
                transform.position.y
            ),
            transform.rotation
        );

        yield return new WaitForSecondsRealtime(2); // TODO: not working
    }
}
