using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float velocidad = 5f; // Velocidad de persecuci�n
    [SerializeField] NavMeshAgent myAgent;
    void Update()
    {
        if (player == null)
        {
            Debug.LogError("�Asigna el objeto del jugador al campo 'player' en el Inspector!");
            return;
        }

        // Calcula la direcci�n hacia el jugador
        Vector3 direccion = player.position - transform.position;

        myAgent.SetDestination(player.position);

        // Opcional: mira hacia la direcci�n del jugador (descomenta la siguiente l�nea si deseas activar esto)
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direccion), 0.1f);
    }
}
