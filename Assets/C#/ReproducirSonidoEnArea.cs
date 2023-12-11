using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirSonidoEnArea : MonoBehaviour
{
    public AudioClip sonido;
    private AudioSource audioSource;

    private void Start()
    {
        // Aseg�rate de que el objeto tenga un componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Aseg�rate de que el sonido est� asignado
        if (sonido != null)
        {
            audioSource.clip = sonido;
        }
        else
        {
            Debug.LogWarning("�No se ha asignado un clip de sonido!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� en el �rea tiene el Layer "�reaSonido"
        if (other.gameObject.layer == LayerMask.NameToLayer("�reaSonido"))
        {
            // Reproduce el sonido
            audioSource.Play();
        }
    }
}
