using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceGameOverMenu : MonoBehaviour
{
    public GameObject textScore;

    // Use this for initialization
    void Start()
    {
        // Mostramos la puntuacion final
        textScore.gameObject.GetComponent<TextMesh>().text = string.Format("GAME OVER\n\nFinal Score: {0}", GameManager.score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // Ponemos los valores por defecto
        GameManager.lives = 3;
        GameManager.level = 1;
        GameManager.score = 0;
        GameManager.trap1Activated = false;
        GameManager.trap2Activated = false;

        // Reproducimos el sonido de la tecla pulsada
        GetComponent<AudioSource>().Play();

        // Cargamos la escena del juego
        SceneManager.LoadScene("PinballCustom");
    }

}
