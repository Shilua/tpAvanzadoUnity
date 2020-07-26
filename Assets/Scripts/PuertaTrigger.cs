using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PuertaTrigger : MonoBehaviour
{
    GameObject puerta;
    
    private void OnTriggerEnter(Collider collider)
    {
        puerta = GameObject.Find("DoorDouble");
            if(puerta != null && puerta.activeSelf)
            {
                puerta.SetActive(false);
                StartCoroutine(activaPuerta(puerta, 4f));
            }

        
    }

    IEnumerator activaPuerta(GameObject puerta, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        puerta.SetActive(true);
    }

}
