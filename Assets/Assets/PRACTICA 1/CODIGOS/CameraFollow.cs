using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controla el seguimiento de la camara de la bola
/// </summary>



public class CameraFollow : MonoBehaviour
{

    // TODO: Referencia al objetivo (bola)
    public Transform objetivo;

    //TODO: Offset o separacion entre la camara y el objetivo
    // Transform position x y z 
     public Vector3 offset = new Vector3(0f, 3f, -6f);


    //TODO: Variable para activar o desactivar el seguimiento
    private bool seguir = false;

    void LateUpdate()
    {
        //PISTA: Solo seguir si esta activado ye el objetivo
        //esta correctamente referenciado
        if (seguir && objetivo != null)
        {
            //PISTA: Posicionar camara con offset

             transform.position = objetivo.position + offset;
        }
    }

    //PISTA: Metodo para iniciar seguimiento
    public void iniciarSeguimiento()
    {
        seguir = true;
    }

    //PISTA: Metodo para detener seguimiento()
    public void DetenerSeguimiento()
    {
       seguir = false;  
     
    }
}
