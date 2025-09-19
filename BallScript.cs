using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    // Fysikk delen
    public Rigidbody2D myRigidbody;
    // Hvor sterk ballen hopper når du trykker space
    public float flapStrength = 20;
    // Referanse til logikken (poeng, game over osv..)
    public LogicScript logic;
    // Holder styr på om ballen lever eller har dødd
    public bool ballIsAlive = true;
    
    //  AudioSource-komponenten som spiller av hoppelyden (lastet ned som .mp3 lydfyl og la i assets og dro den opp i inspectoren)
    public AudioSoucre jumpSound;
    // AudioSource-komponenten som spiller av kollisjonslyden 
    public AudioSource collisionSound;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Finner logic objektet i scenen og hent LogicScript-komponenten
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hvis spilleren trykker space og ballen lever
        if (Input.GetKeyDown(KeyCode.Space) == true && ballIsAlive == true)
        {
            // Ballen hopper oppver 
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            // Når du trykker space, så kommer "jumpSound" lyden for hver trykk
            jumpSound.PlayOneShot(jumpSound.clip);
        }

        
    }

    // Kalles når ballen treffer noe som pipe
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Når ballen treffer pipen, så kommer kollisjon lyden til å spilles av
        collisionSound.Play();
        // Kjører gameOver funksjonen i logic scriptet
        logic.gameOver();
        // Markerer at ballen ikke lever lenger
        ballIsAlive = false;
    }
}
