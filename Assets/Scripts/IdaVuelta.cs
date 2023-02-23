using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdaVuelta : MonoBehaviour
{

    [Tooltip("Distancia que se moverá el objeto por segundo en metros.")]
    public float velocidad = 5.0f;

    [Tooltip("Distancia máxima que recorrerá el objeto antes de volver.")]
    public float distanciaMaxima = 20.0f;

    //En posicionInicial guardamos la posición de origen de cada uno
    //de los caminos de ida y de vuelta
    private Vector3 posicionInicial;

    // Con direccion controlamos cuando el objeto va y vuelve
    // y cuando cambia de ida a vuelta y viceversa
    // Cuando es TRUE el objeto está en el camino de ida (Adelante)
    // Cuando es FALSE el objeto está en el camino de vuelta (Atrás)
    private bool direccion;


    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos la posicion y la direccion
        posicionInicial = transform.position;
        direccion = true;
        Debug.Log("Hacia adelante");
    }

    // Update is called once per frame
    void Update()
    {
        // Llamamos al metodo MovimientoIdaVuelta que será el que realizará el recorrido
        MovimientoIdaVuelta();
    }

    private void MovimientoIdaVuelta()
    {
        // Si es movimiento es hacia adelante...
        if (direccion)
        {
            // Avanzamos a través del eje Z (Azul)
            transform.position = transform.position + transform.forward * velocidad * Time.deltaTime;

            // Calculamos la distancia entre el origen del tramo y el objeto
            float distanciaOrigen = Vector3.Distance(posicionInicial, transform.position);

            // Si esa distancia es mayor que la máxima cambiamos la dirección
            // e inicializamos la posicion origen del tramo
            if (distanciaOrigen > distanciaMaxima)
            {
                direccion = false;
                posicionInicial = transform.position;
                Debug.Log("Hacia atrás");
            }
        }
        else // Si el movimiento es hacia atrás, hacemos el mismo proceso pero retrocediendo en el eje Z
        {
            transform.position = transform.position - transform.forward * velocidad * Time.deltaTime;

            float distanciaOrigen = Vector3.Distance(posicionInicial, transform.position);
            if (distanciaOrigen > distanciaMaxima)
            {
                direccion = true;
                posicionInicial = transform.position;
                Debug.Log("Hacia adelante");
            }
        }
    }
}
