using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarComida : MonoBehaviour
{
    [Tooltip("Objeto a generar")]
    public GameObject generarObjeto = null;

    [Tooltip("Tiempo entre la generación de un objeto y otro")]
    public float tiempoGenerar = 4.0f;

    // Tiempo que va trasncurriendo hasta que aparezca el siguiente objeto
    private float siguienteObjeto = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos el tiempo que va transcurriendo
        siguienteObjeto = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementamos el tiempo
        siguienteObjeto += Time.deltaTime;


        // Si el tiempo transcurrido es superior al establecido creamos el objeto
        // y reiniciamos de nuevo el contador del tiempo
        if (siguienteObjeto > tiempoGenerar)
        {
            // Definimos de forma aleatoria la posicion "x" y "z" donde aparecerá el objeto
            // El rango del número aleatorio será (-50, 50) para cubrir todo el suelo
            float posX = Random.Range(-50, 50);
            float posZ = Random.Range(-50, 50);

            // Colocamos el objeto en la posición definida anteriormente
            Vector3 posicionAleaoria = new Vector3(posX, 0, posZ);

            // Creamos el objeto
            GameObject objetoGameObject = Instantiate(generarObjeto, posicionAleaoria, Quaternion.identity, null);

            siguienteObjeto = 0f;
        }
    }
}
