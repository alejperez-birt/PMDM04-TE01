using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {

    [Tooltip("Objeto alrededor del que girará.")]
	public Transform objeto;
    [Tooltip("Velocidad de rotacion")]
	public int velocidadGiro = -100;
	
	void Start() {
		// Si no se ha definido ningún objeto por defecto dara vueltas alrededor de él mismo
		if (objeto == null) 
		{
			objeto = this.gameObject.transform;

		}
    }

	// Update is called once per frame
	void Update () {
		// Hacemos que el objeto gire alrededor del objeto designado
		transform.RotateAround(objeto.transform.position,objeto.transform.up,velocidadGiro * Time.deltaTime);

    }
}
