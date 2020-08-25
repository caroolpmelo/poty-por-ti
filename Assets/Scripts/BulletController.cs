using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public enum Letter
    {
        A,
        W,
        S,
        D
    }

    private void Start()
    {
        // set bullet to destroy itself after 1s
        Destroy(gameObject, 1.0f);

        // push bullet to direction it's facing
        //GetComponent<Rigidbody2D>()
        //    .AddForce(transform.up * 400);
    }

    private void Update()
    {
        //OnKeyPressed();
    }

    // key A, key W
    //private void OnKeyPressed()
    //{ 
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        Debug.Log("funfou");
    //    }
    //}
}
