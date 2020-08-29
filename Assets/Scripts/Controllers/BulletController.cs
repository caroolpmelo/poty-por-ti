using UnityEngine;

public class BulletController : MonoBehaviour
{
    private ScoreManager scoreManager = ScoreManager.Instance;
    private AudioManager audioManager = AudioManager.Instance;

    // audio props
    [SerializeField]
    private Letter musicalType;
    private AudioClip shootSound;

    public enum Letter
    {
        A,
        W,
        S,
        D
    }

    private void Start()
    {
        musicalType = (Letter)Random.Range(0, 4); // set bullet type

        //Destroy(gameObject, 2.0f); // destroy itself after seconds
        PlayBulletSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); // destroy bullet

            // TODO: change enemy color based on damage

            scoreManager.AddScore();
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
