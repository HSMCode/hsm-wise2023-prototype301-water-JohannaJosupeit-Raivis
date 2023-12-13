using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiStuff : MonoBehaviour
{
    private GameObject startScreen;
    private Vector3 targetSize, startSize;
    // Start is called before the first frame update
    void Start()
    {
        startScreen = GameObject.Find("StartScreen");
        targetSize = startScreen.transform.localScale * 3f;
        startSize = startScreen.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!playerMovement.isAlive)
        {
            
            float t = 0f;
            t += Time.deltaTime;
            startScreen.SetActive(true);
            /*
            if (t < 1f)
            {
                startScreen.transform.localScale = Vector3.Lerp(startScreen.transform.localScale, startSize, t * 6f);
            }
            */
        }

        else if (playerMovement.isStarted)
        {
            
            float t = 0f;
            t += Time.deltaTime;
            if (t < 0.95f)
            {
                
                startScreen.transform.localScale = Vector3.Lerp(startScreen.transform.localScale, targetSize, t* 2f);
            }
            else
            {
                startScreen.SetActive(false);
            }
            

        }
        
        
        
    }
}
