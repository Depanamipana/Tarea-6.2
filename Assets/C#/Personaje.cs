using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    public string escenaSiguiente; // Asigna el nombre de la escena a cargar en el Inspector

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto con el que colisionamos tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Invoca la función para cargar la escena con un retraso de 3 segundos
            Invoke("CargarEscenaSiguiente", 2.1f);
        }
    }

    void CargarEscenaSiguiente()
    {
        // Asegúrate de que el nombre de la escena esté configurado
        if (!string.IsNullOrEmpty(escenaSiguiente))
        {
            SceneManager.LoadScene(escenaSiguiente);
        }
        else
        {
            Debug.LogWarning("Nombre de la escena no especificado en el script.");
        }
    }
}
