using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDanio : MonoBehaviour
{
    public float atenuacion;
    public void RecibirDanio(float danio)
    {
        Vida vida = GetComponentInParent<Vida>();
        float valor = danio * this.atenuacion;
        if(vida != null)
        {
            vida.cantidad -= valor;
        }
    }
}
