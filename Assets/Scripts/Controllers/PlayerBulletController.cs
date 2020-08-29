using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private ScoreManager scoreManager = ScoreManager.Instance;
    private AudioManager audioManager = AudioManager.Instance;

    private SpriteRenderer sp;

    // audio props
    [SerializeField]
    private Letter musicalType;
    private AudioClip shootSound;

    // score sprites
    [SerializeField]
    private List<Sprite> musicSprites = new List<Sprite>(4);

    public enum Letter
    {
        A,
        W,
        S,
        D
    }

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        musicalType = (Letter)Random.Range(0, 4); // set bullet type
        sp.sprite = musicSprites[(int)musicalType]; // set sprites

        Destroy(gameObject, 2.0f); // destroy itself after seconds
        PlayBulletSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); // destroy bullet
            Destroy(collision.gameObject); // destroy enemy

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
