using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoPerseguir : MonoBehaviour
{
    public MonoBehaviour enemigoPerdido;
    public MonoBehaviour enemigoEnRango;
    private Agente agente;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<Agente>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(agente.enemigoActual.transform.position);
    }
}
