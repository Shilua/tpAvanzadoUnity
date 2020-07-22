using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class EstadoAtacar : MonoBehaviour
{
    public MonoBehaviour enemigoFueraRango;
    public MonoBehaviour enemigoMuerto;
    private Animator animator;
    private Agente agente;
    public LayerMask layers;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<Agente>();
    }

    void OnEnable()
    {
        print("enable");
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", false);
        animator.SetBool("Run", false);
        animator.SetBool("Fire", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (agente.enemigoActual == null)
        {

            CancelInvoke("Disparar");
            enemigoMuerto.enabled = true;
            enabled = false;
        }

        InvokeRepeating("Disparar", 0, 0.5f);

        float distancia = Vector3.Distance(transform.position, agente.enemigoActual.transform.position);

        if(distancia > agente.rangoAtaque)
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
            animator.SetBool("Fire", false);
            CancelInvoke("Disparar");
            enemigoFueraRango = GetComponent<EstadoPerseguir>();
            enemigoFueraRango.enabled = true;
            enabled = false;
        }
    }

    void Disparar()
    {
        
        RaycastHit hit;
        float largoDelRayo = 50f;
        Vector3 otroVector = transform.forward;
        otroVector.y += agente.rangoAleatorio;
        //Ray shootRay = new Ray(transform.position, transform.forward);
        Vector3 vectorAPj = agente.enemigoActual.transform.position - transform.position;
        vectorAPj.Normalize();
        vectorAPj.y += agente.rangoAleatorio;
        bool choco = Physics.Raycast(transform.position, vectorAPj, out hit, largoDelRayo, layers);
        print(choco);
        if (choco)
        {
            print("pew pew");
        }
    }
}
