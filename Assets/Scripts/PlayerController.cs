using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _velocity = 5f;

    void Start()
    {
        transform.position = Vector3.zero; // start player in the center
    }

    void Update()
    {
        MovePlayer();
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
}
