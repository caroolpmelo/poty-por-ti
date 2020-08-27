using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Backtexan : MonoBehaviour
{
    private Material mat;
    private Vector2 offset;

    [SerializeField]
    public float speed = 0.15f;

    void Start()
    {
        mat = gameObject.GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        offset.x = offset.x + (speed * Time.deltaTime);
        mat.SetTextureOffset("_MainTex", offset);
        mat.SetTextureOffset("_MainTex", offset);
    }
}
