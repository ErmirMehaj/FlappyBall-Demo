
using UnityEngine;
using UnityEngine.UI; // For å vise tekst på skjermen (UI)
using UnityEngine.SceneManagement; // For å kunne restarte scenen/spillet

public class LogicScript : MonoBehaviour
{
    // Holder styr på spillerens poeng
    public int playerScore;
    // Referanse på UI teksten som viser poeng
    public Text scoreText;
    // Referanse til Game-Over skjermen
    public GameObject gameOverScreen;
    // AudioSource-komponenten som spiller av score lyd når du passerer en pipe
    public AudioSource scoreSound;

    // Lar deg øke poeng fra Unity Editor (høyreklikk på scriptet -> Increase Score)
    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        // Legger til poeng
        playerScore = playerScore + scoreToAdd;
        // Oppdaterer UI teksten
        scoreText.text = playerScore.ToString();
        // Her spilles lyden når du går opp en score
        scoreSound.PlayOneShot(scoreSound.clip);
    }

    // Restarter spillet ved å reloade scenen
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        // Viser game over skjermen
        gameOverScreen.SetActive(true);
    }
}
