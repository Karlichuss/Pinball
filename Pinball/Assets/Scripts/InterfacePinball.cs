using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfacePinball : MonoBehaviour {

    public Text lives;
    public Text level;
    public Text score;

	// Use this for initialization
	void Start () {
        // Ponemos los valores por defecto
        GameManager.lives = 3;
        GameManager.level = 1;
        GameManager.score = 0;

        // Iniciamos las animaciones


    }
	
	// Update is called once per frame
	void Update () {
        // Vamos actualizando el numero de vidas que quedan
        lives.text = string.Format("Lives: {0}", GameManager.lives);
        // El nivel actual
        level.text = string.Format("Level: {0}", GameManager.level);
        // Y la puntuacion
        score.text = string.Format("Score: {0}", GameManager.score);
    }
}
