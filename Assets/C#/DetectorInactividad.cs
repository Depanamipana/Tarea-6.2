using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectorInactividad : MonoBehaviour
{
    public float tiempoInactividad = 5f;
    public string nombreEscenaACargar = "NombreDeTuEscena"; // Nombre predeterminado
    public GameObject objetoActivarDesactivar;

    private float tiempoSinMovimiento = 0f;
    private Vector3 posicionAnterior;

    void Start()
    {
        // Al inicio, almacenamos la posición inicial del jugador
        posicionAnterior = transform.position;

        // Desactivar el objeto al inicio
        if (objetoActivarDesactivar != null)
        {
            objetoActivarDesactivar.SetActive(false);
        }
    }

    void Update()
    {
        // Verificar si el jugador se ha movido
        if (transform.position != posicionAnterior)
        {
            // Si se ha movido, reiniciar el contador
            tiempoSinMovimiento = 0f;
            posicionAnterior = transform.position;

            // Desactivar el objeto al moverse
            if (objetoActivarDesactivar != null)
            {
                objetoActivarDesactivar.SetActive(false);
            }
        }
        else
        {
            // Si no se ha movido, aumentar el contador
            tiempoSinMovimiento += Time.deltaTime;

            // Activar el objeto y cargar la escena especificada
            if (objetoActivarDesactivar != null && tiempoSinMovimiento >= 0.1f)
            {
                objetoActivarDesactivar.SetActive(true);
            }

            // Verificar si ha pasado el tiempo de inactividad
            if (tiempoSinMovimiento >= tiempoInactividad)
            {
           
                CargarEscena(nombreEscenaACargar);
            }
        }
    }

    void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
