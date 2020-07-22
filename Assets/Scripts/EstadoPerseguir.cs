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
    public LayerMask layers;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<Agente>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        navMeshAgent.SetDestination(agente.enemigoActual.transform.position);
        Vector3 vectorAPj = agente.enemigoActual.transform.position - transform.position;
        vectorAPj.Normalize();
        bool choco = Physics.Raycast(transform.position, vectorAPj, out hit, agente.rangoVision, layers);
        if (!choco)
        {
            enemigoPerdido = GetComponent<EstadoPatrullar>();
            enemigoPerdido.enabled = true;
            enabled = false;
        }

        float distancia = Vector3.Distance(transform.position, agente.enemigoActual.transform.position);

        if (distancia < agente.rangoAtaque)
        {
            enemigoEnRango = GetComponent<EstadoAtacar>();
            enemigoEnRango.enabled = true;
            enabled = false;
        }
    }

}
