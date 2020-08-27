using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 starScale;
    
    void Start()
    {
        starScale = transform.localScale;

       
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        
        transform.localScale = new Vector3(width, height, starScale.z);

    }

    // Update is called once per frame
    void Update()
    {

    }

}