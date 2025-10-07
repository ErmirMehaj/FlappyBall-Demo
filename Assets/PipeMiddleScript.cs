using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic; // Referanse til LogicScript (For å kunne legge til score)
    void Start()
    {
        // Finner LogicScript-objectet i scenen
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Når ballen (layer 3) passerer gjennom midten av pipen
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1); // Legger til 1 poeng via LogicScript

        }
        
    }
}
