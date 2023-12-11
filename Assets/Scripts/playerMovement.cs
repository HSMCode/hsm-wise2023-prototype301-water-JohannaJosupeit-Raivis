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
        isStarted = true;
        isAlive = true;
        score = 0;
        exactScore = 0;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }
    void FixedUpdate()
    {
        if(isAlive)
        {
            exactScore += Time.deltaTime;
        }
      
    }
    // Update is called once per frame
    void Update()
    {
        score = Mathf.RoundToInt(exactScore);
        scoreText.text = "Score: " + score;
        //DEATH
        if (!isAlive)
        {
            
            animator.SetBool("isAlive", false);
            rb.useGravity = true;
            
            
        }

     // START
        if (Input.GetButtonDown("Jump") && !isAlive)
        {
            Debug.Log("Restart");
            SceneManager.LoadScene("EndlessLevel");
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
        Vector3 clampedPosition = transform.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -1.5f, 1.5f);
        transform.localPosition = clampedPosition;
    }
}
