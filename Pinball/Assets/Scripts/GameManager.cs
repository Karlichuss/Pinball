///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: GameManager.cs
///////////////////////////////

using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Declaración de variables

    // Numero de vidas que le quedan al jugador
    public static int lives = 3;
    // Nivel
    public static int level = 1;
    // Puntuacion
    public static int score = 0;

    // Para controlar que no se reproduzcan en cada update un sonido y asi mejorar el rendimiento, utilizaremos diferentes booleanos
    // Control del sonido de los flipper
    public static bool LFlipperSoundPlay = false;
    public static bool RFlipperSoundPlay = false;
    
    // Control del sonido de la bola
    public static bool ballSoundPlay = false;

    // Control de la activacion de las trampas
    public static bool trap1Activated = false;
    public static bool trap2Activated = false;

    // Control de los botones del leap motion
    public static bool leftPressed = false;
    public static bool rightPressed = false;
    public static bool plungerPressed = false;

    #endregion

}
