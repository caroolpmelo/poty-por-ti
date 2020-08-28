using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;

    private ScoreManager scoreManager = ScoreManager.Instance;
    private AudioManager audioManager = AudioManager.Instance;

    [SerializeField]
    private Letter musicalType;
    private AudioClip shootSound;

    private int bulletSpeed = 400;

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

        transform.rotation = Quaternion.Euler(Vector3.zero);

        musicalType = (Letter)Random.Range(0, 4); // set bullet type

        rb.AddForce(transform.right * bulletSpeed); // push to direction it's facing
        Destroy(gameObject, 2.0f); // destroy itself after seconds

        PlayBulletSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            scoreManager.AddScore();
            Destroy(gameObject);
            //Destroy(collision.gameObject);
        }
    }

    private void PlayBulletSound()
    {
        shootSound = audioManager.GetRandomSound();

        if (shootSound)
        {
            // play correspondent musical sound
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
        }
    }
}
