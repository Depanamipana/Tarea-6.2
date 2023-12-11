using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerConActivacionDesactivacion : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float tiempoInicial = 300f;
    public GameObject objetoADesactivar1;
    public GameObject objetoADesactivar2;
    public GameObject objetoAActivar;

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
        if (!temporizadorActivado) return;
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        string tiempoTexto = string.Format("{0:00}:{1:00}", minutos, segundos);

        if (timerText != null)
        {
            timerText.text = tiempoTexto;
        }
    }

    void TiempoAgotado()
    {
        DesactivarObjetos();
        ActivarObjeto();
        DetenerTemporizador();
    }

    void DesactivarObjetos()
    {
        if (objetoADesactivar1 != null)
        {
            objetoADesactivar1.SetActive(false);
        }

        if (objetoADesactivar2 != null)
        {
            objetoADesactivar2.SetActive(false);
        }
    }

    void ActivarObjeto()
    {
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(true);
        }
    }

    public void IniciarTemporizador()
    {
        temporizadorActivado = true;
    }

    public void DetenerTemporizador()
    {
        this.enabled = false;
        temporizadorActivado = false;
    }
}
