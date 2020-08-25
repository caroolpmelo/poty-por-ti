using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _velocity = 5f;

    private void Start()
    {
        transform.position = Vector3.zero; // start player in the center
    }

    private void Update()
    {
        MovePlayer();
        OnKeyPressed();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontalInput, verticalInput);

        if (_velocity != 0)
        {
            // when idle, direction will be zero, so anything * 0 = 0
            transform.Translate(direction * _velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        { 
            Debug.Log("funcionou");
        }
    }

    private void OnKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("TIRO");
        }
    }
}
