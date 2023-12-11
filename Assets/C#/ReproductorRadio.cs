using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorRadio : MonoBehaviour
{
    public AudioClip[] clipsDeAudio; // Asigna los clips de audio en el Inspector
    private AudioSource audioSource;

    private int indiceActual = 0; // Índice del clip de audio actual

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (clipsDeAudio.Length > 0)
        {
            ReproducirAudio();
        }
        else
        {
            Debug.LogWarning("No se han asignado clips de audio.");
        }
    }

    void Update()
    {
        // Cambiar estación de radio al presionar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            CambiarEstacion();
        }
    }

    void ReproducirAudio()
    {
        audioSource.clip = clipsDeAudio[indiceActual];
        audioSource.Play();
    }

    void CambiarEstacion()
    {
        if (clipsDeAudio.Length == 0)
        {
            Debug.LogWarning("No se han asignado clips de audio.");
            return;
        }

        // Detener la reproducción del clip actual
        audioSource.Stop();

        // Avanzar al siguiente clip de audio en el array
        indiceActual = (indiceActual + 1) % clipsDeAudio.Length;

        // Asignar y reproducir el nuevo clip de audio
        ReproducirAudio();
    }
}
