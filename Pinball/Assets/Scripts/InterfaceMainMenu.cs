using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceMainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
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