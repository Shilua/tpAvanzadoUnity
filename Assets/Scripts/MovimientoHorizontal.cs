using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class MovimientoHorizontal : MonoBehaviour
{

    
    public Vector3 direction;
    public float speed;
    public float range;

    private float timer;
    private float minLimit;
    private float maxLimit;


    void Start()
    {
        minLimit = transform.position.x;
        maxLimit = range;
    }


    // Update is called once per frame
    void Update()
    {
        //timer += 1 * Time.deltaTime;
        Invoke("Movimiento", 2f);

        //speed += timer;
    }

    void Movimiento()
    {
        if (transform.position.x > maxLimit)
        {
            speed *= -1;
        }


        if (transform.position.x < minLimit)
        {
            speed *= -1;
        }



        transform.Translate(direction * speed * Time.deltaTime);
    }
}
