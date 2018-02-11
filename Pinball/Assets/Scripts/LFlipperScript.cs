///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: LFipperScript.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LFlipperScript : MonoBehaviour {

    #region Declaración de variables

    [Header("Physics")]
    [Tooltip("Ángulo de posicion en reposo")]
    public float restPosition = 0f;
    [Tooltip("Ángulo de posicion presionado")]
    public float pressedPosition = 45f;
    [Tooltip("Fuerza del golpe de impacto")]
    public float hitStrength = 30000;
    [Tooltip("Fuerza del flipper")]
    public float flipperDamper = 1000f;
    [Tooltip("Nombre de la entrada")]
    public string inputName;

    [Header("HingeJoint y JointSpring")]
    [Tooltip("Punto sobre el que pivota el flipper")]
    HingeJoint hingeJoint;
    [Tooltip("Fuerza opuesta a la que pueda girar el flipper")]
    JointSpring spring;

    #endregion

    #region Métodos

    /// <summary>
    /// Método que es llamado cuando el GameObject es instanciado
    /// </summary>
    void Start () {
        /// Recuperamos el hingejoint
        hingeJoint = GetComponent<HingeJoint>();
        /// Recuperamos el spring
        hingeJoint.useSpring = true;

        /// Inicializamos el jointSpring
        spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };
    }
	
	/// <summary>
    /// Método que es llamado en cada frame
    /// </summary>
	void Update () {
         
        /// Si se pulsa el botón correspondiente:
        if (Input.GetAxis(inputName) == 1 || GameManager.leftPressed)
        {
            ///     Si el sonido esta disponible:
            if (GameManager.LFlipperSoundPlay)
            {
                ///         Controlamos que se haga la orden solo una vez
                GameManager.LFlipperSoundPlay = false;
                ///         Reproducimos el sonido del flipper
                GetComponent<AudioSource>().PlayDelayed(Time.deltaTime);
            }

            ///     Y giramos el flipper
            spring.targetPosition = pressedPosition;
        }

        /// Y si no se pulsa el botón:
        else
        { 
            ///     Ponemos el sonido a que este disponible
            GameManager.LFlipperSoundPlay = true;
            ///     Giramos el flipper a su posicion original
            spring.targetPosition = restPosition;
        }

        /// Asignamos el spring correspondiente para que el flipper se mueva de verdad
        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;

        /// Y controlamos que en el Leap Motion solo salte una vez
        GameManager.leftPressed = false;

    }

    /// <summary>
    /// Método llamado cuando se pulsa el botón correspondiente con el Leap Motion
    /// </summary>
    public void Action()
    {
        ///     Hacemos que para el siguiente frame se simule que se ha pulsado la tecla correspondiente del teclado
        GameManager.leftPressed = true;
    }

    #endregion

}
