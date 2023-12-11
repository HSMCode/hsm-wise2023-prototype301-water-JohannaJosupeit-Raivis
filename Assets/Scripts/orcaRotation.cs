using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orcaRotation : MonoBehaviour
{
    public float YrotationSpeed = 1f;
    public float XrotationSpeed = 1f;

    void Update()
    {
        float Yangle = Mathf.Sin(Time.time * YrotationSpeed) * 30f;
        transform.rotation = Quaternion.Euler(0f, Yangle, 0f);
        float Xangle = Mathf.Sin(Time.time + 1f * XrotationSpeed) * 30f;
        transform.rotation = Quaternion.Euler(Xangle, 0f, 0f);
    }
}
