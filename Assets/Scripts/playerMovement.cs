using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    private int score;
    private Animator animator;
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    public static float exactScore;
    private bool moveUp = true;
    private Text scoreText;
    public static bool isAlive, isStarted;
    


    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        isAlive = true;
        score = 0;
        exactScore = 0;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }
   
    // Update is called once per frame
    void Update()
    {
        score = Mathf.RoundToInt(exactScore);
        scoreText.text = "Score:" + exactScore;

     // START
        if (Input.GetKeyDown(KeyCode.R) && !isAlive)
        {
            SceneManager.LoadScene("Level_0");
        }
        else if (Input.GetButtonDown("Jump") && !isStarted)
        {
           isStarted = true;
        }
        // MOVEMENT
        else if (Input.GetButtonDown("Jump"))
        {
            // Change direction when space is pressed
            moveUp = !moveUp;
        }

        if (isStarted && isAlive)
        {
            MoveObject();
        }
      
    }

    void MoveObject()
    {
        // Switch between 2 floats depending on a bool
        float moveDirection = moveUp ? 1f : -1f;
        // Calculate movement in local space
        float translation = moveDirection * speed * Time.deltaTime;

        // Move the object along the y-axis
        transform.Translate(new Vector3(0f, translation, 0f));

        // Stop at -1 or 1 on the y-axis
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -1.5f, 1.5f);
        transform.position = clampedPosition;
    }
}
