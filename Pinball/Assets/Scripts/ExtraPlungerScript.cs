using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPlungerScript : MonoBehaviour
{

    #region Declaración de variables

    [Header("Psycics")]
    [Tooltip("La fuerza con la que se va a lanzar la bola")]
    public float power;

    [Header("GameObjects")]
    [Tooltip("La bola que entra en el plunger")]
    GameObject ball;
    [Tooltip("La trampilla que va a cerrarse cuando el plunger se usa")]
    public GameObject trap;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando algo entra en la CollisionBox del GameObject
    /// </summary>
    /// <param name="other">Lo que entra en la CollisionBox</param>
    private void OnTriggerEnter(Collider other)
    {
        /// Si lo que entra tiene la tag Ball:
        if (other.tag.Equals("Ball"))
        {
            ///     Recuperamos el GameObject
            ball = other.gameObject;
            ///     Llamamos en un hilo secundario la secuencia de lanzamiento
            StartCoroutine(LaunchBall());
        }
    }

    /// <summary>
    /// Método asincronico que lanza la bola
    /// </summary>
    /// <returns></returns>
    IEnumerator LaunchBall()
    {
        /// Reproducimos el sonido del evento
        GetComponent<AudioSource>().Play();

        /// Hacemos tiempo a que se reproduzca el sonido
        Time.timeScale = 1;

        /// Pausamos el hilo por 1 segundo
        yield return new WaitForSeconds(1.0f);

        /// Lanzamos la bola hacia arriba
        ball.GetComponent<Rigidbody>().AddForce(power * Vector3.forward);

        /// Pausamos 0.5 segundos para dar tiempo a que la bola salga del plunger
        yield return new WaitForSeconds(0.5f);

        /// Si el nivel del juego es mayor o igual que 2 y la trampilla aun no se ha activado:
        if (GameManager.level >= 2 && !GameManager.trap1Activated)
        {
            ///     Ponemos que ya se ha activado
            GameManager.trap1Activated = true;
            ///     Cerramos la trampilla para que este extra no pueda volver a usarse
            trap.gameObject.GetComponent<Animation>().Play();
        }
    }

    #endregion

}
