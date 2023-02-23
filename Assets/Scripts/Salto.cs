using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    [Tooltip("Tiempo que transcurre entre un salto y el siguiente.")]
    public float tiempoSalto = 1.0f;

    [Tooltip("Altura de salto.")]
    public float altoSalto = 1.5f;

    [Tooltip("Velocidad de salto.")]
    public float velocidadSalto = 4.0f;

    // Contador de tiempo hasta que tiene que iniciar el siguiente salto
    private float inicioSalto = 0f;

    // Nos indica la dirección del salto
    // Cuando es TRUE el objeto está subiendo (Ascender)
    // Cuando es FALSE el objeto está bajando (Descender)
    private bool ascender;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos el contador del tiempo y la direccion
        inicioSalto = 0f;
        ascender = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementamos el tiempo
        inicioSalto += Time.deltaTime;

        // Si el tiempo transcurrido es superior al establecido hay movimiento
        if (inicioSalto > tiempoSalto)
        {
            // Si esccender es TRUE subimos en el eje vertical
            if (ascender)
            {
                transform.position = transform.position + transform.up * velocidadSalto * Time.deltaTime;

                // Si la posición alcanzada en vertical es superior al limite del salto
                // cambiamos el movimiento a descender
                if (transform.position.y > altoSalto)
                {
                    ascender = false;
                }
            }
            else // Si ascender es FALSE descendemos en el eje vertical 
            {
                transform.position = transform.position - transform.up * velocidadSalto * Time.deltaTime;

                // Si se llega de nuevo al suelo, cambiamos el movimiento a ascender
                // y reiniciamos de nuevo el contador del tiempo
                if (transform.position.y <= 0)
                {
                    ascender = true;
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                    inicioSalto = 0f;
                }
            }
        }
    }
}
