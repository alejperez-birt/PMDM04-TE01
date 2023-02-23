using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirComida : MonoBehaviour
{

    [Tooltip("Tiempo de vida de cada objeto")]
    public float tiempoDestruir = 6.0f;

    // Tiempo que va transcurriendo hasta que se destruye el objeto
    private float destruirObjeto = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializamos el tiempo que transcurre hasta que se destruye el objeto
        destruirObjeto = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Incrementamos el tiempo
        destruirObjeto += Time.deltaTime;

        // Modificamos la escala del objeto para que vaya creciendo hasta desaparecer
        transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);

        // Si el tiempo tanscurrido supera el tiempo establecido para destruir el objeto, lo destruimos
        if (destruirObjeto > tiempoDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
