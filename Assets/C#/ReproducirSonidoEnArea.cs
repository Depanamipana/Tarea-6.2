using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirSonidoEnArea : MonoBehaviour
{
    public AudioClip sonido;
    private AudioSource audioSource;

    private void Start()
    {
        // Asegúrate de que el objeto tenga un componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asegúrate de que el sonido esté asignado
        if (sonido != null)
        {
            audioSource.clip = sonido;
        }
        else
        {
            Debug.LogWarning("¡No se ha asignado un clip de sonido!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el área tiene el Layer "ÁreaSonido"
        if (other.gameObject.layer == LayerMask.NameToLayer("ÁreaSonido"))
        {
            // Reproduce el sonido
            audioSource.Play();
        }
    }
}
