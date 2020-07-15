using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFPS : MonoBehaviour
{
    private float angulo;
    private float angulo2;
    // Update is called once per frame
    void Update()
    {
        this.angulo += -Input.GetAxis("Mouse Y");
        this.angulo = Mathf.Clamp(angulo, -45, 45);
        transform.localEulerAngles = new Vector3(angulo, 0, 0);
    }
}
