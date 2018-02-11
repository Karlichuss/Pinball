///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: InterfaceGameOverMenu.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceGameOverMenu : MonoBehaviour
{
    #region Declaración de variables

    public GameObject textScore;

    #endregion

    #region Métodos

    /// <summary>
    /// Método llamado cuando el GameObject es instanciado
    /// </summary>
    void Start()
    {
        /// Mostramos la puntuacion final
        textScore.gameObject.GetComponent<TextMesh>().text = string.Format("GAME OVER\n\nFinal Score: {0}", GameManager.score.ToString());
    }

    /// <summary>
    /// Método que es llamado cuando se hace click
    /// </summary>
    public void OnClick()
    {
        /// Ponemos los valores por defecto
        GameManager.lives = 3;
        GameManager.level = 1;
        GameManager.score = 0;
        GameManager.trap1Activated = false;
        GameManager.trap2Activated = false;

        /// Reproducimos el sonido de la tecla pulsada
        GetComponent<AudioSource>().Play();

        /// Cargamos la escena del juego
        SceneManager.LoadScene("PinballCustom");
    }

    #endregion

}
