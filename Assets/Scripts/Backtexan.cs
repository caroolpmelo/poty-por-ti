using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Backtexan : MonoBehaviour
{
    private Material mat;
    private Vector2 offset;

    [SerializeField]
    public float speed = 0.2f;



    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
        
    }

    // Update is called once per frame
    void Update()
    {
        offset.x = offset.x + (speed * Time.deltaTime);
        mat.SetTextureOffset("_MainTex", offset);
        mat.SetTextureOffset("_MainTex", offset);


    }
}
