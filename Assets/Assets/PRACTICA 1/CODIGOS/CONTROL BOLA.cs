using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controla el movimiento lateral y el lanzamiento de la bola.
/// Tambien se comunica con la camara y el sistema de puntuacion.
/// </summary>
public class ControlBola : MonoBehaviour
{
    //TODO: Fuerza con la que se lanza la bola
    public float fuerzaDeLanzamiento = 1000f;
    public Transform CamaraPrincipal;
    public Rigidbody rb;

    //TODO: Velocidad y limites para el apuntado.
    public float velocidadDeApuntado = 5f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    //TODO:Referencias internas
  
    private bool haSidoLanzada=false;

    //TODO:Referencia a la camara y al score
    public CameraFollow cameraFollow;
    public ScoreManager scoreManager;

    //if aninado, controlan otros 

    // Start is called before the first frame update
    void Start()
    {
        //PISTA: Obtener el componente Rigibody de esta bola
        rb = GetComponent<Rigidbody>();
          
    }

    // Update is called once per frame
    void Update()
    {
        //Expresion:mientras que haSidoLanzada sea falso puedes disparar
        if (haSidoLanzada==false)
        {
            Apuntar();
            //PISTA: si se presiona espacio, lanzar la bola
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
        
    }
    void Apuntar()
    {
        //1.Leer un input Horizontal de tipo Axis, te pernite registrar
        //entradas con las teclas A y D y Flecha izquierda y Flecha derecha
        //PISTA: Obtener el movimiento horizontal (-1 a 1)
        float inputHorizontal = Input.GetAxis("Horizontal");
        //PISTA:    Mover la bola hacia los lados
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);
        //pista: Delimitar el movimiento de la bola
        Vector3 posicionActual = transform.position;
        //transform.position me perimte saber cual es la posicion actual de la escena
        posicionActual.x=Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);
        transform.position = posicionActual;//se coloca de nuevo pq se actualiza la posicion
    }

    void Lanzar()// empieza un metodo
    {
        haSidoLanzada = true;
        //EJEMPLO EXPLICADO: Comprobar si el Rigidbody existe antes de usarlo
        // Esta comprobacion evita errores NullReferenceException
        //Si olvidamos arrastrar el Rigidbody o el componente fue eliminado,
        //el sistema no deberia intentar usarlo
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);

        }
        else
        {
            Debug.LogWarning("El Rigidbody no esta asignado en " + gameObject.name);
        }

        //PISTA:Iniciar seguimiento de la camara(si existe)
        if (cameraFollow != null) cameraFollow.iniciarSeguimiento();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //PISTA:Si colisiona con un pino
        if (collision.gameObject.CompareTag("Pin")) 
        {
            //PISTA:Detener el seguimiento de la camara(di no es null)
            if (cameraFollow != null) cameraFollow.DetenerSeguimiento();
        //PISTA:Calcular puntaje tras un pequeño retraso
        if(scoreManager!=null)Invoke("CalcularPuntaje",0f);
        }
    }
    void CalcularPuntaje()
    { 
    //  PISTA:Llamar al ScoreManager para actualizar los puntos
    scoreManager.CalcularPuntaje();
    }

}//Bienvenido a la entrada al infierno
