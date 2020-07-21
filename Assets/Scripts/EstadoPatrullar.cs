using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPatrullar : MonoBehaviour
{
    public MonoBehaviour enemigoDetectado;
    private NavMeshAgent navMeshAgent;
    public Transform[] puntos;
    private int puntoActual;
    private Transform destino;
    private Agente agente;
    public LayerMask layers;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<Agente>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        puntoActual = 0;
        destino = puntos[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.hasPath && navMeshAgent.remainingDistance < 0.5f)
        {
            puntoActual++;
            destino = puntos[puntoActual];
            navMeshAgent.SetDestination(destino.position);
        }

        if (puntoActual == puntos.Length - 1)
        {
            puntoActual = 0;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, 10, layers);

        for (int i = 0 ; i > colliders.Length; i++)
        {
            Transform jugadorEnRango = colliders[i].gameObject.transform;
            Vector3 vectorAPj = jugadorEnRango.position - transform.position;
            vectorAPj.Normalize();
            float dot = Vector3.Dot(transform.forward, vectorAPj);
            if(dot > 0.5)
            {
               agente.enemigoActual = colliders[i].gameObject;

            }

        }
    }
}
