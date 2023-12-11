using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartLevel : MonoBehaviour
{
    private bool isPaused = false; // Variable para verificar si el juego está pausado

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.GetComponent<TextMeshProUGUI>() == GetComponent<TextMeshProUGUI>())
            {
                if (isPaused)
                {
                    Resume(); // Si el juego está pausado, resumir en lugar de reiniciar
                }
                else
                {
                    Pause(); // Si no está pausado, pausar el juego
                }
            }
        }
    }

    public void Restart()
    {
        // Reinicia el nivel actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Pause()
    {
        // Pausar el juego
        Time.timeScale = 0; // Pausa el tiempo en el juego
        isPaused = true;
        // Aquí puedes agregar lógica adicional, como mostrar un mensaje de pausa en la pantalla
    }

    public void Resume()
    {
        // Continuar desde la pausa
        Time.timeScale = 1; // Reanuda el tiempo en el juego
        isPaused = false;
        // Aquí puedes agregar lógica adicional, como ocultar el mensaje de pausa
    }
}
