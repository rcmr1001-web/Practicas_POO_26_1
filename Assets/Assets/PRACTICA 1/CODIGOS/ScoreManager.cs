using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Calcula cuantos pinos estan caidos y muestra el puntaje en pantalla
/// </summary>

public class ScoreManager : MonoBehaviour
{
    // TODO: Texto UI
    public Text textoPuntaje;

    //TODO: Variables internas
    private int puntajeActual = 0;

    [SerializeField]
    private Pin[] pinos;

    // Start is called before the first frame update
    void Start()
    {
        textoPuntaje.text = "Tienes un millon de dolares";

        // PISTA: Buscar todos los objetos tipo Pin
         pinos = FindObjectsOfType<Pin>();
    }

    public void CalcularPuntaje()
    {
        int puntaje = 0;

        //PISTA: Revisar cada pino si esta caido
        foreach (Pin pin in pinos)
        {
             if (pin.EstaCaido()) { puntaje++;}
        }

        puntajeActual = puntaje;

        //PISTA: Actualizar texto del puntaje (validar si TextoPuntaje != null)
         if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;

    }

}
