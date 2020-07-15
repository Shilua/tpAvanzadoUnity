using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuertaTrigger : MonoBehaviour
{
    GameObject puerta;
    
    private void OnTriggerEnter(Collider collider)
    {
        puerta = GameObject.Find("Puerta");
            if(puerta != null && puerta.activeSelf)
            {
                puerta.SetActive(false);
                StartCoroutine(activaPuerta(puerta, 2f));
            }

        
    }

    IEnumerator activaPuerta(GameObject puerta, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        puerta.SetActive(true);
    }

}
