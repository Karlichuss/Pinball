///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: TrapController.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {

    #region Métodos

    /// <summary>
    /// Método que es llamado en cada frame
    /// </summary>
    void Update () {
        /// Si el nivel del juego es 4 y es la primera vez que esto pasa:
        if (GameManager.level == 4 && !GameManager.trap2Activated)
        {
            ///     Controlamos que esto no pueda activarse de nuevo
            GameManager.trap2Activated = true;

            ///     Abrimos la trampilla
            GetComponent<Animation>().Play();
        }
    }

    #endregion
}
