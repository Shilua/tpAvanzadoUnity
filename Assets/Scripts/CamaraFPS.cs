using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFPS : MonoBehaviour
{
    private float anguloX;
    private float anguloY;
    private float mouseSensitive = 100f;
    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }

    // Update is called once per frame
    void Update()
    {
        this.anguloX = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;
        playerBody = this.transform.parent.transform;
        playerBody.Rotate(Vector3.up * this.anguloX);
        this.anguloY += -Input.GetAxis("Mouse Y");
        this.anguloY = Mathf.Clamp(anguloY, -45, 45);
        transform.localEulerAngles = new Vector3(anguloY, 0, 0);
    }
}
