using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public static float moveSpeed;
    private float offset;
    private Material mat;

   
    public float amplitude = 1f;

    private void Start()
    {
        moveSpeed = 2f;
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * moveSpeed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

    }

}
