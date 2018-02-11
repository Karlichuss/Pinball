///////////////////////////////
// Práctica: Pinball
// Alumno: Antonio Carlos Ordoñez Cintrano
// Curso: 2017/2018
// Fichero: PowerUpController.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {

    #region Declaración de variables

    // Partículas de chispas
    public GameObject flare;

    #endregion

    #region Métodos
	
	/// <summary>
    /// Método que es llamado en cada frame
    /// </summary>
	void Update () {
        /// Hacemos que vaya girando en el aire
        transform.Rotate(new Vector3(12, 30, 45) * Time.deltaTime);
    }

    /// <summary>
    /// Método que es llamado cuando algo entra dentro de la CollisionBox del GameObject
    /// </summary>
    /// <param name="other">Lo que entra en la CollisionBox</param>
    private void OnTriggerEnter(Collider other)
    {
        /// Si lo que entra tiene la tag Ball:
        if (other.gameObject.tag.Equals("Ball"))
        {
            ///     Puntuamos
            GameManager.score += 50 * GameManager.level;
            ///     Subimos de nivel
            GameManager.level += 1;
            ///     Instanciamos las particulas de powerup
            Instantiate(flare, transform.position, Quaternion.identity);
            ///     El powerup desaparece
            Destroy(gameObject);
        }
    }

    #endregion

}
