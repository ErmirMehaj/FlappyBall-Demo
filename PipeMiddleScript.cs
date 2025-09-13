using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    // Referanse til LogicScript for å kunne øke poeng
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Henter LogicScriptet fra objektet med taggen Logic
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    // Når ballen passerer midten av pipen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Layer 3 er som regel spilleren, eller ballen da
        if (collision.gameObject.layer == 3)
        {
            // Poenget økes med 1 for hver gang ballen passerer en pipe
            logic.addScore(1);
        }
        
    }
}
