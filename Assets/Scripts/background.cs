using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float Speed;
    private float offset;
    private Material mat;

    public float movementSpeed = 1f;
    public float amplitude = 1f;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * Speed) / 10;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));


        float verticalMovement = Mathf.Sin(Time.time * movementSpeed) * amplitude;
        transform.position = new Vector3(transform.position.x, verticalMovement, transform.position.z);
    }

}
