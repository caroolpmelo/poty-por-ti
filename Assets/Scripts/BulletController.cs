using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;

    private ScoreManager scoreManager = ScoreManager.Instance;

    [SerializeField]
    private Letter musicalType;
    
    private int velocity = 400;

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

        musicalType = (Letter)Random.Range(0, 4); // set bullet type
        rb.AddForce(transform.right * velocity); // push to direction it's facing
        Destroy(gameObject, 2.0f); // destroy itself after seconds
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("funcionou bala");
            scoreManager.AddScore();
        }
    }
}
