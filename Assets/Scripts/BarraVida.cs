using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public GameObject jugador;
    private EnemyManager enemyManager;
    private Vida vida;
    public Image barra;
    //public Text count;
    // Start is called before the first frame update
    void Start()
    {
        vida = jugador.GetComponent<Vida>();
        //enemyManager = this.GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        barra.fillAmount = vida.cantidad / 100;
        //count.text = enemyManager.enemigosMuertos.ToString();
    }
}
