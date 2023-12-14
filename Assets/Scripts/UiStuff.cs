using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// honestly i forgot why this works. it shouldn't work. but it does??? 
// better dont touch it - it might fall apart

public class UiStuff : MonoBehaviour
{
    private GameObject startScreen;
    private Vector3 targetSize, startSize;

    // Start is called before the first frame update
    void Start()
    {
        // find and store the text stuff
        startScreen = GameObject.Find("StartScreen");
        // the text scales up to this size while playing
        targetSize = startScreen.transform.localScale * 3f;
        // the size where the text is readable
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
