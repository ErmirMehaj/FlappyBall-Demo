using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody; // Referanse til ballens fysikk
    public float flapStrength = 20; // Styrken på hoppet, hvor sterkt ballen hopper
    public LogicScript logic; // Referanse til logicscript for å kunne starte spillet
    
    public bool ballIsAlive = false; // Sjekker om ballen er levende

    public AudioSource jumpSound; // Lyd som spilles hver gang ballen hopper
    public AudioSource collisionSound; // Lyd som spilles ved kollisjon

    void Start()
    {
        // Finner LogicScript i scenen (på Logic Manager-objektet)
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.simulated = false; // Ballen fryst i starten (fysikken er skrudd av)

    }
    void Update()
    {
        // Før spillet starter: Hvis spilleren trykker space -> start spillet
        if (!logic.gameHasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            logic.startGame(); // StartGame i LogicScript
            ActiveBall();
            return; // Stopper her slik at vi ikke hopper i samme frame
        }
        // Når spillet er startet og ballen lever -> space = hopp
        if (logic.gameHasStarted && Input.GetKeyDown(KeyCode.Space) == true && ballIsAlive == true)
        {
            // Gir ballen ny oppoverfart
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            jumpSound.PlayOneShot(jumpSound.clip); // Spiller hoppelyden
        }
        
        // Hvis spilleren går for langt ned (< -20) eller for langt opp (< 20) -> Game Over
        if (transform.position.y < -20 || transform.position.y > 20 && ballIsAlive)
        {
            logic.gameOver();
            ballIsAlive = false; // Skrur av ballen
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Hvis ballen lever og treffer noe (pipe) -> Game Over
        if (ballIsAlive)
        {

            collisionSound.Play(); // Kollisjonslyd
            logic.gameOver(); // Game Over skjerm
            ballIsAlive = false; // Deaktiver ball

        }

    }

    public void ActiveBall() // Aktiverer ballen når spillet har startet
    {
        ballIsAlive = true;
        myRigidbody.simulated = true; // Skrur på physics når spillet starter
    }
}
