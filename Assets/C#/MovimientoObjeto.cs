using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObjeto : MonoBehaviour
{
    public float veloInicial = 5f; // Velocidad inicial en el eje Z
    public float tiempoDeMovimiento = 3f; // Tiempo de movimiento en segundos

    private void Start()
    {
        // Llama a la funci�n para iniciar el movimiento despu�s de un tiempo determinado
        Invoke("IniciarMovimiento", tiempoDeMovimiento);
    }

    private void IniciarMovimiento()
    {
        // Aseg�rate de que el objeto tiene un componente Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("El objeto necesita tener un componente Rigidbody.");
            return;
        }

        // Asigna la velocidad inicial en el eje Z
        Vector3 velocidad = new Vector3(0f, 0f, veloInicial);
        rb.velocity = velocidad;
    }
}
