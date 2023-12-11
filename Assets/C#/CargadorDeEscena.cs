using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargadorDeEscena : MonoBehaviour
{
    public string nombreDeLaEscenaACargar = "NombreDeTuEscena";

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Cargar la escena especificada
            CargarEscena();
        }
    }

    void CargarEscena()
    {
        if (!string.IsNullOrEmpty(nombreDeLaEscenaACargar))
        {
            SceneManager.LoadScene(nombreDeLaEscenaACargar);
        }
        else
        {
            Debug.LogError("Nombre de escena no especificado en el cargador de escena.");
        }
    }
}
