using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //character controller stuff
    private CharacterController characterController;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;


    //camera stuff
    public Camera mainCam;
    private bool cursorlocked;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;


    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // lock cursor at start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorlocked = true;

    }

    // Update is called once per frame
    void Update()
    {
        //cursor lock
        if (Input.GetKeyDown("escape") && cursorlocked == true)
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cursorlocked = false;
        }
        if (Input.GetKeyDown("escape") && cursorlocked == false)
        {
            // turn off the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursorlocked = true;
        }

        //movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        Vector3 moveNormalized = Vector3.ClampMagnitude(moveDirection, (isRunning ? runSpeed : walkSpeed));


        //jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }



        //rotation
        characterController.Move(moveNormalized * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            mainCam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }





}
