using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Usa TextMeshProUGUI en lugar de Text
    public float tiempoInicial = 300f; // Tiempo inicial en segundos, puedes ajustarlo en el Inspector
    public string escenaSiguiente; // Nombre de la escena a cargar cuando el temporizador llega a 0

    private float tiempoTranscurrido = 0f;
    public bool temporizadorActivado = false;

    void Start()
    {
        tiempoTranscurrido = tiempoInicial;
        ActualizarTextoTemporizador();
    }

    void Update()
    {
        if (temporizadorActivado)
        {
            tiempoTranscurrido -= Time.deltaTime;
            

            if (tiempoTranscurrido <= 0f)
            {
                TiempoAgotado();
            }
            ActualizarTextoTemporizador();
        }
    }

    void ActualizarTextoTemporizador()
    {
        if(temporizadorActivado == false) return; 
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        string tiempoTexto = string.Format("{0:00}:{1:00}", minutos, segundos);

        // Actualiza el objeto TextMeshProUGUI con el tiempo transcurrido
        if (timerText != null)
        {
            timerText.text = tiempoTexto;
        }
    }

    void TiempoAgotado()
    {
        DetenerTemporizador();

        // Carga la siguiente escena cuando el temporizador llega a 0
        if (!string.IsNullOrEmpty(escenaSiguiente))
        {
            SceneManager.LoadScene(escenaSiguiente);
        }
    }

    public void IniciarTemporizador()
    {
        
        // Inicia el temporizador
        temporizadorActivado = true;
    }

    public void DetenerTemporizador()
    {
        this.enabled = false;
        // Detiene el temporizador
        temporizadorActivado = false;
    }
}
