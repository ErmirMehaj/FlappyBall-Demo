using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // Hastigheten pipene beveger seg mot venstre
    public float moveSpeed = 5;
    // Når pipen er for langt til venstre (utenfor skjermen), slettes den
    public float deadZone = -45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Flytter pipen mot venstre i jevn hastighet
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        // Sjekker om pipen har passert deadzone (langt utenfor skjermen)
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe deleted"); // Logg til konsollen (nyttig for debugging)
            Destroy(gameObject); // Fjerner pipen fra spillet
        }
    }
}
