using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe; // Prefab (pipe-objektet) som skal spawnes inn
    public float spawnRate = 3.5f; // Hvor ofte pipes skal dukke opp (sekunder mellom spawn)
    private float timer = 0; // Teller tiden mellom hver spawn
    public float heightOffset = 10; // Hvor mye høyden på pipen kan variere

    public bool gameIsActive = false; // Om spillet er aktivt eller ikke (styres av LogicScript)

    void Update()
    {
        if (!gameIsActive) return; // Hvis spillet ikke er aktvt -> gjør ingenting
        if (timer < spawnRate) // Teller opp timeren til den når spawnRate
        {
            timer = timer + Time.deltaTime; // Legger til tid hvert frame
        }
        else
        { 
            // Når timer >= spawnRate -> spawn en ny pipe
            spawnPipe();
            timer = 0; // Reset timer
        }

    }

    void spawnPipe()
    { 
        // Regner ut laveste og høyeste posisjon pipen kan spawnes på
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        // Lager en ny pipe ved en tilfeldig høyde mellom lowest og highest
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    
    }
}
