
using UnityEngine;
using UnityEngine.UI; // For å vise tekst på skjermen (UI)
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting; // For å kunne restarte scenen/spillet

public class LogicScript : MonoBehaviour
{
    // Holder styr på spillerens poeng
    public int playerScore;
    // Referanse på UI teksten som viser poeng
    public Text scoreText;

    // Referanse til Game-Over skjermen
    public GameObject gameOverScreen;

    // Instruksjonsteksten (f.eks. "Press space to jump")
    public GameObject instructiontext;
    
    // Referanse til ballen (spilleren)
    public BallScript ball;

    // Referanse til pipe spawneren (lager nye piper)
    public PipeSpawnerScript spawner;

    // Lyd som spilles når man får poeng
    public AudioSource scoreSound;

    // Fart på pipene
    public float pipeSpeed = 5f;

    // Holder på beste poengsum (lagres mellom spill)
    private int highScore = 0;

    // Tekstfeltet som viser highscore
    public TextMeshProUGUI highScoreText;


    void Start()
    {
        // Henter highscoren fra lagring (PlayerPrefs)
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        // Skjuler highscore-teksten til det blir Game Over    
        highScoreText.gameObject.SetActive(false); 
    }

    // Lar deg øke poeng fra Unity Editor (høyreklikk på scriptet -> Increase Score)
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        // Legger til poeng
        playerScore = playerScore + scoreToAdd;
        // Oppdaterer UI teksten
        scoreText.text = playerScore.ToString();
        // Spiller av poeng-lyden
        scoreSound.Play();

        // Hver gang spilleren får 5 poeng, så øker pipe-farten
        if (playerScore % 5 == 0)
        {
            pipeSpeed += 0.5f;
        }
    }


    // Restarter spillet ved å reloade scenen
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Sjekker om spillet har startet eller ikke
    public bool gameHasStarted = false;
    // Kalles når spillet starter (første gang spilleren trykker space) 
    public void startGame()
    {

        instructiontext.SetActive(false); // Skjuler instruksjonsteksten
        gameHasStarted = true; // Setter spillet til aktivt
        ball.ActiveBall(); // Aktiverer ballen slik at ballen kan hoppe
        spawner.gameIsActive = true; // Starter pipe-spawning
    }

    public void gameOver() // Kalles når spilleren dør
    {
        // Viser game over skjermen
        gameOverScreen.SetActive(true);
        spawner.gameIsActive = false; // Stopper pipe spawning

        if (playerScore > highScore) // Sjekker om spilleren fikk ny highscore
        {
            highScore = playerScore; // Oppdaterer scoren
            PlayerPrefs.SetInt("Highscore", highScore); // Lagrer highscoren
            PlayerPrefs.Save(); // Sørger for at den lagres på disk
        }
        // Viser highscore på Game Over skjermen
        highScoreText.text = "Highscore: " + highScore; 
        highScoreText.gameObject.SetActive(true);
    }
   
}
