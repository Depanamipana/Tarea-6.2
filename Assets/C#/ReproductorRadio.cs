using System.Collections;
using UnityEngine;

public class ReproductorRadio : MonoBehaviour
{
    public string carpetaRecursos = "CarpetaDeRecursos";
    private AudioClip[] clipsDeAudio;
    private AudioSource audioSource;

    private int indiceActual = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Cargar clips de audio desde la carpeta de recursos
        clipsDeAudio = Resources.LoadAll<AudioClip>(carpetaRecursos);

        if (clipsDeAudio.Length > 0)
        {
            ReproducirAudio();
        }
        else
        {
            Debug.LogWarning($"No se encontraron clips de audio en la carpeta de recursos: {carpetaRecursos}");
        }
    }

    void Update()
    {
        // Cambiar estación de radio aleatoriamente al presionar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            CambiarEstacionAleatoria();
        }

        // Retroceder estación de radio al presionar la tecla Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RetrocederEstacion();
        }

        // Comprobar si ha terminado de reproducir el clip actual y cambiar a la siguiente estación
        if (!audioSource.isPlaying)
        {
            CambiarEstacionAleatoria();
        }
    }

    void ReproducirAudio()
    {
        audioSource.clip = clipsDeAudio[indiceActual];
        audioSource.Play();
    }

    void CambiarEstacionAleatoria()
    {
        if (clipsDeAudio.Length == 0)
        {
            Debug.LogWarning($"No se encontraron clips de audio en la carpeta de recursos: {carpetaRecursos}");
            return;
        }

        // Detener la reproducción del clip actual
        audioSource.Stop();

        // Seleccionar aleatoriamente el siguiente clip de audio en el array
        indiceActual = ObtenerIndiceAleatorioExceptoActual();

        // Asignar y reproducir el nuevo clip de audio
        ReproducirAudio();
    }

    void RetrocederEstacion()
    {
        if (clipsDeAudio.Length == 0)
        {
            Debug.LogWarning($"No se encontraron clips de audio en la carpeta de recursos: {carpetaRecursos}");
            return;
        }

        // Detener la reproducción del clip actual
        audioSource.Stop();

        // Retroceder al clip anterior en el array
        indiceActual = (indiceActual - 1 + clipsDeAudio.Length) % clipsDeAudio.Length;

        // Asignar y reproducir el nuevo clip de audio
        ReproducirAudio();
    }

    int ObtenerIndiceAleatorioExceptoActual()
    {
        int nuevoIndice = Random.Range(0, clipsDeAudio.Length);

        // Evitar seleccionar el mismo clip de audio actual
        while (nuevoIndice == indiceActual)
        {
            nuevoIndice = Random.Range(0, clipsDeAudio.Length);
        }

        return nuevoIndice;
    }
}
