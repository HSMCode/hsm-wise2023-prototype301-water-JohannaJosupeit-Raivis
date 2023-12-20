using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    bool isSlowing = false;
    float originalTimeScale;
    float slowDuration = 2.5f;
    private float t; // t for time
     public float speed;
     private bool isAlive;
    
    void Start()
    {
        originalTimeScale = Time.timeScale;

        //when the game start the player is alive DUH
        isAlive = true;
        // and the time starts at 0
        t = 0;

         // Aktuelle Rotation des GameObjects speichern
        Vector3 currentRotation = transform.eulerAngles;

        // Rotation um 90 Grad auf der Z-Achse hinzufügen
        currentRotation.z += 90f;

        // Die Rotation des GameObjects aktualisieren
        transform.eulerAngles = currentRotation;
        

    }

        private void OnTriggerEnter(Collider other)
    {
        if(isAlive && other.gameObject.CompareTag("Player") && playerMovement.isStarted && !isSlowing)
        {
            StartCoroutine(SlowDownTime());

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
        }
        
    }

   void Update()
    {
        // Time.deltaTime = time in seconds that passed since the last frame
        // counting the seconds by adding the passed time to t
        t += Time.deltaTime;
        // after 50 seconds
        if (t > 50f)
        {
            //in a desperate attempt to save the game performence deactivate this object.
            this.gameObject.SetActive(false);
        }
        // if the player is alive during this frame
        if (playerMovement.isAlive)
        {
            //move the object forward (on the z- axis). The distance depends on how much time passed since the last frame and its speed
            transform.position = transform.position - transform.forward * speed * 2* Time.deltaTime;
        }
     
    }



    IEnumerator SlowDownTime()
    {
        isSlowing = true;
        Time.timeScale = 0.5f; // Halbiert die Spielgeschwindigkeit

        yield return new WaitForSeconds(slowDuration);

        Time.timeScale = originalTimeScale; // Stellt die normale Spielgeschwindigkeit wieder her
        isSlowing = false;
    }
}