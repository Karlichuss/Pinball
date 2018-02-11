using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando algo colisiona con el GameObject
    /// </summary>
    /// <param name="collision">Lo que colisiona con el GameObject</param>
    private void OnCollisionEnter(Collision collision)
    {
        /// Si lo que colisiona tiene la tag Ball:
        if (collision.gameObject.tag.Equals("Ball"))
        {
            ///     Reproducimos el sonido de la colisión
            GetComponent<AudioSource>().Play();

            ///     Si el sonido de la bola no esta activado:
            if (GameManager.ballSoundPlay)
            {
                ///         Controlamos que no vuelva a darse la orden de que suene la bola
                GameManager.ballSoundPlay = false;
                ///         Reproducimos en bucle el sonido de la bola rodando hasta que esta deje de entrar en contacto con el suelo
                collision.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    /// <summary>
    /// Método que es llamado cuando algo deja de estar en contacto con el GameObject
    /// </summary>
    /// <param name="collision">Lo que ha estado en contacto con el GameObject</param>
    private void OnCollisionExit(Collision collision)
    {
        /// Si lo que ha dejado de estar en contacto tiene la tag Ball:
        if (collision.gameObject.tag.Equals("Ball"))
        {
            ///     Detenemos el sonido de la bola rodando, porque esta en el aire
            collision.gameObject.GetComponent<AudioSource>().Stop();
            ///     Volvemos a poner disponible el sonido
            GameManager.ballSoundPlay = true;
        }
    }

    #endregion
}
