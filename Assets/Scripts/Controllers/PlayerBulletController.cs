using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : BulletController
{
    private ScoreManager scoreManager = ScoreManager.Instance;
    private AudioManager audioManager = AudioManager.Instance;
    private EnemyManager enemyManager = EnemyManager.Instance;

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

        int lettersQuantity = System.Enum.GetValues(typeof(Letter)).Length;
        musicalType = (Letter)Random.Range(0, lettersQuantity); // set bullet type

        sp.sprite = musicSprites[(int)musicalType]; // set sprites
        sp.transform.localScale = new Vector3(0.05f, 0.05f); // scale obj (it's big)

        PlayBulletSound();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject); // destroy bullet
            scoreManager.AddScore();

            // change enemy sprite
            enemyManager.SetDefeatSprite(gameObject);
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
