using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private LogicScript logic; // Referanse til LogicScript (for å hente pipeSpeed)
    public float deadZone = -45; // Hvor langt til venstre pipen kan gå før den slettes
    void Start()
    {
        // Finner LogicScript-objektet i scenen
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Update()
    { 
        // Flytter pipen mot venstre med fart = pipeSpeed
        transform.position = transform.position + (Vector3.left * logic.pipeSpeed) * Time.deltaTime;
        // Hvis pipen har gått for langt til venstre -> slett den
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted"); // Debug-melding i konsollen
            Destroy(gameObject); // Fjerner pipen fra scenen
        }
    }
}
