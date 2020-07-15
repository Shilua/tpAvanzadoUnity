using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private int puntoActual;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Transform destino;
    public Vector3 direction;
    public float speed;
    public LayerMask layers;
    public Transform[] puntos;
    //public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        puntoActual = 0;
        destino = puntos[0];
        navMeshAgent.SetDestination(destino.position);
        this.animator = GetComponent<Animator>();
        this.animator.SetBool("Idle", false);
        this.animator.SetBool("Run", true);
    }

    void Update()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.hasPath && navMeshAgent.remainingDistance < 0.5f)
        {
            puntoActual++;
            destino = puntos[puntoActual];
            navMeshAgent.SetDestination(destino.position);
        }    
        
        if(puntoActual == puntos.Length - 1 )
        {
            puntoActual = 0;
        }
    }

    // Update is called once per frame
    /*void Awake()
    {
        InvokeRepeating("Move", 0, 2f);
    }

    void Move()
    {

        if(this.cont == 0)
        {
            CancelInvoke("Disparar");
            this.animator.SetBool("Idle", true);
            this.animator.SetBool("Run", false);
            this.animator.SetBool("Fire", false);
        }
        else if(this.cont == 1)
        {
            this.animator.SetBool("Idle", false);
            this.animator.SetBool("Run", true);
            this.animator.SetBool("Fire", false);
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            this.animator.SetBool("Idle", false);
            this.animator.SetBool("Run", false);
            this.animator.SetBool("Fire", true);
            InvokeRepeating("Disparar", 0, 0.5f);
        }
        if (this.cont != 2)
        {
            this.cont++;
        }
        else
        {
            this.cont = 0;
        }

    }*/

    void Disparar()
    {
        RaycastHit hit;
        float largoDelRayo = 50.5f;
        bool choco = Physics.Raycast(transform.position, transform.forward, out hit, largoDelRayo, layers);
        if (choco)
        {
            //Instantiate(particle, hit.point, Quaternion.identity);
           
        }
    }
}
