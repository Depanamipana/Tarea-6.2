using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopAudioOnSceneChange : MonoBehaviour
{
    public GameObject pauseMenu; // Asigna el objeto del menú de pausa desde el Inspector
    public List<AudioSource> audioSources; // Lista de AudioSources

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (pauseMenu != null)
        {
            if (pauseMenu.activeSelf)
            {
                PauseAudio();
            }
            else
            {
                ResumeAudio();
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopAllAudio();
    }

    private void PauseAudio()
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null && audioSource.isPlaying && !audioSource.mute)
            {
                audioSource.Pause();
            }
        }
    }

    private void ResumeAudio()
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null && !audioSource.isPlaying && !audioSource.mute)
            {
                audioSource.UnPause();
            }
        }
    }

    private void StopAllAudio()
    {
        foreach (var audioSource in audioSources)
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
