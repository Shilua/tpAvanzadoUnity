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
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<Agente>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        puntoActual = 0;
        destino = puntos[0];
        navMeshAgent.SetDestination(destino.position);
    }

    void OnEnable()
    {
        agente = GetComponent<Agente>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        puntoActual = 0;
        destino = puntos[0];
        navMeshAgent.SetDestination(destino.position);
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
            puntoActual = -1;
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, agente.rangoVision, layers);
        if(colliders.Length != 0)
        {
            Transform jugadorEnRango = colliders[0].gameObject.transform;
            Vector3 vectorAPj = jugadorEnRango.position - transform.position;
            vectorAPj.Normalize();
            float dot = Vector3.Dot(transform.forward, vectorAPj);
            if (dot > agente.anguloVision)
            {
                enemigoDetectado = GetComponent<EstadoPerseguir>();
                enemigoDetectado.enabled = true;
                agente.enemigoActual = colliders[0].gameObject;
                enabled = false;
            }
        }
        
    }
}
