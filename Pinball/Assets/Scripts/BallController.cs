///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: BallController.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Métodos

    /// <summary>
    /// Método que es llamado al final de cada frame. Calcula la velocidad del movimiento de la pelota y en funcion de eso aumentar o disminuir el volumen del sonido de rodadura por el tablero
    /// </summary>
    private void LateUpdate()
    {
        /// Si la pelota se encuentra a una altura menor de cierto valor (esta en el suelo y no en el aire):
        if (GetComponent<Transform>().position.y <= 1)
        {
            /// Calculamos el volumen del sonido del rozamiento de la bola con el suelo segun su velocidad de movimiento
            GetComponent<AudioSource>().volume = Mathf.Clamp((GetComponent<Rigidbody>().velocity.x + GetComponent<Rigidbody>().velocity.z), 0.0f, 1.0f);
        }
        /// Y si esta en el aire:
        else
        {
            /// Silenciamos el sonido de la bola rodando en el suelo, ya que esta en el aire
            GetComponent<AudioSource>().volume = 0.0f;
        }
    }

    #endregion

}
