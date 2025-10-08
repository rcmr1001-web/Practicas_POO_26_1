using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Detecta si el pino ha sido derribado.
/// </summary>
public class Pin : MonoBehaviour
{
    //TODO:Umbral de inclinacion
    private float umbralCaida = 5f;
    public bool EstaCaido()
    { 
    //PISTA:Calcular angulo entre la orientacion del pino y el eje vertical
    float angulo= Vector3.Angle(transform.up,Vector3.up);

        //PISTA: Retornar true si el angulo supera el umbral de caida
        return angulo>umbralCaida;
    }
}
