using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{

    public float maxPower = 100f;
    public Slider powerSlider;

    GameObject ball;

    float power;
    bool ballReady;

    // Use this for initialization
    void Start()
    {
        powerSlider.minValue = 0;
        powerSlider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        powerSlider.value = power;

        if (ballReady)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if (power < maxPower)
                {
                    power += 50 * Time.deltaTime;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                ball.GetComponent<Rigidbody>().AddForce(power * Vector3.forward);
            }
        }
        else
        {
            ballReady = false;
            power = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball = other.gameObject;
            ballReady = true;
            powerSlider.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ball = null;
            ballReady = false;
            powerSlider.gameObject.SetActive(false);
        }
    }
}