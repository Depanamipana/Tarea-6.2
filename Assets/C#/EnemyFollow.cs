using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float velocidad = 5f; // Velocidad de persecución
    [SerializeField] NavMeshAgent myAgent;
    void Update()
    {
        if (player == null)
        {
            Debug.LogError("¡Asigna el objeto del jugador al campo 'player' en el Inspector!");
            return;
        }

        // Calcula la dirección hacia el jugador
        Vector3 direccion = player.position - transform.position;

        myAgent.SetDestination(player.position);

        // Opcional: mira hacia la dirección del jugador (descomenta la siguiente línea si deseas activar esto)
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direccion), 0.1f);
    }
}
