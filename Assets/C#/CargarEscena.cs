using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    public string nombreDeLaEscenaACargar = "NombreDeLaEscena"; // Reemplaza con el nombre de tu escena

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CargarEscenaDeseada();
        }
    }

    private void CargarEscenaDeseada()
    {
        // Carga la escena con el nombre especificado
        SceneManager.LoadScene(nombreDeLaEscenaACargar);
    }
}
