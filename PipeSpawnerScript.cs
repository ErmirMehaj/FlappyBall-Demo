using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    // Referanse til pipe-prefaben som skal spawnes
    public GameObject pipe;
    // Hvor ofte en ny pipe skal komme (i sekunder)
    public float spawnRate = 2;
    // Teller tid frem til neste pipe
    private float timer = 0;
    // Hvor mye høyden kan variere opp og ned
    public float heightOffset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Lager en første pipe med en gang
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        // Teller opp timeren
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            // Når tiden er nådd, spawn en pipe
            spawnPipe();
            timer = 0; // Nullstill timeren
        }

    }

    // Funksjon som lager en pipe på en tilfeldig høyde
    void spawnPipe()
    {
        // Beregn laveste og høyeste punkt for plassering
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        // Lag en pipe på spawnerens x-posisjon og en tilfeldig y-posisjon
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
