using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFPS : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpSpeed = 10.0f;
    private float gravityValue = -9.81f;
    private float angulo;
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y = jumpSpeed;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        this.angulo += Input.GetAxis("Mouse X");
        this.angulo = Mathf.Clamp(angulo, -179, 179);
        transform.eulerAngles = new Vector3(0, angulo, 0);


    }
}
