﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LFlipperScript : MonoBehaviour {

    // Angulo de posicion en reposo
    public float restPosition = 0f;
    // Angulo de posicion presionado
    public float pressedPosition = 45f;
    // Fuerza del golpe de impacto
    public float hitStrength = 30000;
    // Fuerza del flipper
    public float flipperDamper = 300f;
    // Nombre de la entrada
    public string inputName;

    HingeJoint hingeJoint;
    JointSpring spring;

	// Use this for initialization
	void Start () {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useSpring = true;

        spring = new JointSpring
        {
            spring = hitStrength,
            damper = flipperDamper
        };
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis(inputName) == 1)
        {
            Action();
        }
        else
        {
            GameManager.LFlipperSoundPlay = true;
            spring.targetPosition = restPosition;
        }

        hingeJoint.spring = spring;
        hingeJoint.useLimits = true;

	}

    public void Action()
    {
        if (GameManager.LFlipperSoundPlay)
        {
            // Controlamos que se haga la orden solo una vez
            GameManager.LFlipperSoundPlay = false;
            // Reproducimos el sonido del flipper
            GetComponent<AudioSource>().PlayDelayed(Time.deltaTime);
        }
        spring.targetPosition = pressedPosition;
    }
}