using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    public GameObject flare;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Hacemos que vaya girando en el aire
        transform.Rotate(new Vector3(12, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            // Puntuamos
            GameManager.score += 50 * GameManager.level;
            // Subimos de nivel
            GameManager.level += 1;
            // Instanciamos las particulas de powerup
            Instantiate(flare, transform.position, Quaternion.identity);
            // El powerup desaparece
            Destroy(gameObject);
        }
    }
}
