using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 20;
    public LogicScript logic;
    public bool ballIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && ballIsAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        ballIsAlive = false;
    }
}
