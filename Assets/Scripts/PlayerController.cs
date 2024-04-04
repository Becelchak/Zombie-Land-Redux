using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 3.0f;
    private float rotationSpeed = 10f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Transform cameraTransform;

    private Vector3 mPrevPos = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        var input = moveAction.ReadValue<Vector2>();
        var move = new Vector3(input.x, 0, input.y);
        move = move.x * transform.right.normalized + move.z * transform.forward.normalized;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (Input.GetMouseButton(0))
        {
            var mousDelta = Input.mousePosition - mPrevPos;
            transform.Rotate(transform.up, Vector3.Dot(mousDelta, Camera.main.transform.right), Space.World);
        }

        mPrevPos = Input.mousePosition;
    }
}
