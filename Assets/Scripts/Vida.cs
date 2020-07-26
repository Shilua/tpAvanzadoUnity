using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public float cantidad;
    /*public GameObject particle;
    public GameObject sound;
    private GameObject ganar;
    private Canvas canvas;
    private GameObject[] enemies;
    public bool inmunity;
    public GameObject drop;*/


    // Update is called once per frame
    void Update()
    {
        if(cantidad <= 0){
            //Destroy(this.gameObject);
        }

        if(cantidad != 0 && cantidad != 100)
        {
            float addLife = 3 * Time.deltaTime;
            cantidad += addLife;
        }
    }

}
