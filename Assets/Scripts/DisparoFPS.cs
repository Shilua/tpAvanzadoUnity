using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoFPS : MonoBehaviour
{
    public LayerMask layers;
    public GameObject particle;
    private float danio = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("Disparar", 0, 0.5f);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("Disparar");
        }
    }

    void Disparar()
    {
        RaycastHit hit;
        float largoDelRayo = 50.5f;
        bool choco = Physics.Raycast(transform.position, transform.forward, out hit, largoDelRayo, layers);
        if (choco)
        {
            Instantiate(particle, hit.point, Quaternion.identity);
            ZonaDanio vidaDelObjeto = hit.collider.gameObject.GetComponent<ZonaDanio>();
            if (vidaDelObjeto != null)
            {
                vidaDelObjeto.RecibirDanio(danio);
            }
        }
    }
}
