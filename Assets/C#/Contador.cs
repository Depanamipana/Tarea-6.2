using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI textoContador;
    public float tiempoInicial = 5f;

    private float tiempoRestante;

    void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarTextoContador();
    }

    void Update()
    {
        if (tiempoRestante > 0f)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTextoContador();
        }
        else
        {
            tiempoRestante = 0f;
            ActualizarTextoContador();
            // Aquí puedes realizar acciones una vez que el contador llegue a cero
        }
    }

    void ActualizarTextoContador()
    {
        textoContador.text = Mathf.CeilToInt(tiempoRestante).ToString();
    }
}
