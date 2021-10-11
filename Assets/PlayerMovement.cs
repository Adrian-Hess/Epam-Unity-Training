using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    /*
    public Rigidbody rb;
    Vector3 movement;
    public float sensitivHor = 5.0f;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivHor, 0);
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector3)movement * moveSpeed * Time.fixedDeltaTime);
    }*/

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float posX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float posZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(posX, -9.8f, posZ);
        move = Vector3.ClampMagnitude(move, moveSpeed);
        move = transform.TransformDirection(move);

        characterController.Move(move);
    }
}
