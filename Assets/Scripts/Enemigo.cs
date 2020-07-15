using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class Enemigo : MonoBehaviour
{
    private EnemyManager enemyManager;
   
    public void Awake()
    {

        GameObject manager = GameObject.Find("Manager");
        if(manager != null)
        enemyManager = manager.GetComponent<EnemyManager>();
    }

    public void Mori()
    {
        enemyManager.enemigosMuertos += 1;
    }

    
}
