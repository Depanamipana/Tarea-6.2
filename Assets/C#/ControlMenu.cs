using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public GameObject menuCanvas; // Asigna tu Canvas en el Inspector

    void Update()
    {
        // Verifica si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Activa o desactiva el Canvas al presionar Escape
            if (menuCanvas != null)
            {
                bool isMenuActive = !menuCanvas.activeSelf;
                menuCanvas.SetActive(isMenuActive);

                // Pausa o reanuda el juego según si el menú está activo o no
                Time.timeScale = isMenuActive ? 0f : 1f;
            }
        }
    }
}
