using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elipse : MonoBehaviour
{

    [Tooltip("Eje mayor de la elipse.")]
    public float ejeMayor = 7.0f;

    [Tooltip("Eje menor de la elipse.")]
    public float ejeMenor = 3.5f;

    [Tooltip("Velocidad a la que rotará el objeto sobre otro")]
    public float velocidad = 3.0f;

    [Tooltip("Objeto alrededor del que se gira")]
    public Transform objeto;

    private float angulo = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (objeto == null)
        {
            objeto = gameObject.transform;
            Debug.Log("No se ha especificado objeto alrededor del que rotar. Girará sobre sí mismo.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Definimos las posiciones "x" y "z" del objeto en base a la formula de la elipse
        float posX = objeto.transform.position.x + ejeMayor / 2 * Mathf.Cos(angulo);
        float posZ = objeto.transform.position.z + ejeMenor / 2 * Mathf.Sin(angulo);

        // Colocamos el objeto en la posición definida anteriormente
        transform.position = new Vector3(posX, transform.position.y, posZ);

        // Incrementamos el ángulo
        angulo += velocidad * Time.deltaTime;
    }
}
