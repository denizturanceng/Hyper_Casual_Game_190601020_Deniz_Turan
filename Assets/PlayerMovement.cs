using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 3f;
    public CharacterController controller;
    public Joystick joystick; 

   
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        controller.Move(moveDirection * Time.deltaTime * moveSpeed);

        

    }
}