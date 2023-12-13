using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float tiempoEnContactoRequerido = 5f;
    public float tiempoAntesDeReset = 2f;
    public string nombreEscenaACargar = "NombreDeTuEscena";

    private bool estaEnContacto = false;
    private float tiempoEnContacto = 0f;

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el enemigo entra en contacto con el jugador
        if (other.CompareTag("Player"))
        {
            estaEnContacto = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el enemigo deja de estar en contacto con el jugador
        if (other.CompareTag("Player"))
        {
            estaEnContacto = false;
        }
    }

    private void Update()
    {
        // Si el enemigo está en contacto con el jugador, incrementar el tiempo en contacto
        if (estaEnContacto)
        {
            tiempoEnContacto += Time.deltaTime;

            // Si el tiempo en contacto supera el requerido, cargar la escena
            if (tiempoEnContacto >= tiempoEnContactoRequerido)
            {
                CargarEscena(nombreEscenaACargar);
            }
        }
        else
        {
            // Si el jugador no está en contacto, contar el tiempo antes de resetear
            tiempoEnContacto = Mathf.Max(0f, tiempoEnContacto - Time.deltaTime);

            // Si el tiempo en contacto es cero, reiniciar
            if (tiempoEnContacto == 0f)
            {
                tiempoEnContacto = 0f;
            }
        }

        // Si el tiempo en contacto se mantiene por encima de cero durante el tiempo antes de resetear, reiniciar
        if (tiempoEnContacto > 0f && tiempoEnContacto >= tiempoAntesDeReset)
        {
            tiempoEnContacto = 0f;
            Debug.Log("Tiempo en contacto reseteado.");
        }
    }

    void CargarEscena(string nombreEscena)
    {
        // Implementa aquí la lógica para cargar la escena si es necesario
        Debug.Log("Cargar escena: " + nombreEscena);
        // SceneManager.LoadScene(nombreEscena);
    }
}
