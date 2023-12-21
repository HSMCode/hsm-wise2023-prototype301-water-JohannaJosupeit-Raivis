using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePosition : MonoBehaviour
{
    public float yOffset = 3f; // Die Anzahl, um die die Y-Position erhöht werden soll

    void Start()
    {
        // Aktuelle Position des GameObjects
        Vector3 currentPosition = transform.position;

        // Y-Position um 'yOffset' erhöhen
        currentPosition.y += yOffset;

        // Die Position des GameObjects aktualisieren
        transform.position = currentPosition;
    }
}