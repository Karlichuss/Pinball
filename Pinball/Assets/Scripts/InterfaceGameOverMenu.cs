using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceGameOverMenu : MonoBehaviour
{
    public Text textScore;

    // Use this for initialization
    void Start()
    {
        // Mostramos la puntuacion final
        textScore.text = string.Format("Final Score: {0}", GameManager.score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // Cargamos la escena del juego
        SceneManager.LoadScene("PinballCustom");
    }

}
