///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: PlungerController.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerController : MonoBehaviour {

    #region Declaración de variables

    [Header("Physics")]
    [Tooltip("Potencia máxima que puede tener")]
    public float maxPower = 100f;
    [Tooltip("El slider que va a decir cuánta potencia va a tener")]
    public Slider powerSlider;

    [Header("GameObjects")]
    [Tooltip("La bola que se va a lanzar")]
    GameObject ball;

    [Header("GameObject Physics")]
    [Tooltip("La fuerza con la que se va a lanzar la bola")]
    float power;
    [Tooltip("Determina si hay una bola lista para ser lanzada o no")] 
    bool ballReady;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando el GameObject es instanciado
    /// </summary>
    void Start()
    {
        /// Ponemos los valores por defecto
        powerSlider.minValue = 0;
        powerSlider.maxValue = maxPower;
    }

    /// <summary>
    /// Método que es llamado en cada frame
    /// </summary>
    void Update()
    {
        /// Si hay una bola lista:
        if (ballReady)
        {
            ///     Si se pulsa la tecla correspondiente:
            if (Input.GetKey(KeyCode.Space))
            {
                ///         Si la potencia puede incrementarse aun mas:
                if (power < maxPower)
                {
                    ///             Incrementamos la potencia
                    power += 50 * Time.deltaTime;
                }
            }

            ///     Si se suelta la tecla correspondiente:
            if (Input.GetKeyUp(KeyCode.Space))
            {
                ///     Se aplica una fuerza a la bola
                ball.GetComponent<Rigidbody>().AddForce(power * Vector3.forward);
            }

            ///     Si se pulsa a traves del Leap Motion al botón correspondiente:
            if (GameManager.plungerPressed)
            {
                ///     Se aplica a la bola la fuerza maxima
                ball.GetComponent<Rigidbody>().AddForce(maxPower * Vector3.forward);
            }

            /// Y se vuelve a dejar el boton disponible
            GameManager.plungerPressed = false;
        }

        /// Y si no hay una bola lista:
        else
        {
            ///     Volvemos a dejar todos los valores por defecto
            ballReady = false;
            power = 0.0f;
        }
    }

    /// <summary>
    /// Método que es llamado al final de cada frame
    /// </summary>
    private void LateUpdate()
    {
        /// Actualiza el valor del Slider segun la fuerza a aplicar a la bola
        powerSlider.value = power;
    }

    /// <summary>
    /// Método que es llamado cada vez que algo entra dentro de la CollisionBox del GameObject
    /// </summary>
    /// <param name="other">Lo que ha entrado dentro del GameObject</param>
    private void OnTriggerEnter(Collider other)
    {
        /// Si lo que ha entrado tiene el tag Ball:
        if (other.gameObject.CompareTag("Ball"))
        {
            ///     Recuperamos el GameObject
            ball = other.gameObject;
            ///     Notificamos de que hay una bola lista
            ballReady = true;
            ///     Activamos el slider para que pueda ser visible la fuerza que vamos a aplicar
            powerSlider.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Método que es llamado cada vez que algo sale de dentro de la CollisionBox del GameObject
    /// </summary>
    /// <param name="other">Lo que sale del GameObject</param>
    private void OnTriggerExit(Collider other)
    {
        /// Si lo que sale tiene el tag Ball:
        if (other.gameObject.CompareTag("Ball"))
        {
            ///     Volvemos a los valores por defecto
            ball = null;
            ballReady = false;
            powerSlider.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Método que es llamado cada vez que con el Leap Motion presionamos el botón correspondiente
    /// </summary>
    public void Action()
    {
        GameManager.plungerPressed = true;
    }

    #endregion

}
