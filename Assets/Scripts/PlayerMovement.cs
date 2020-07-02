using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField] private float forwardMoveSpeed = 7.5f;
    [SerializeField] private float backwardMoveSpeed = 3f;
    [SerializeField] private float stafeMoveSpeed = 3f;
    [SerializeField] private float turnSpeed = 150f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        //TODO: Make toggle and move to own script. Abort locking in game with Alt + Tab
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");
        var strafe = Input.GetAxis("Horizontal");

        //var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);
        animator.SetFloat("Strafe", strafe);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (strafe != 0)
        {
            characterController.SimpleMove(transform.right * stafeMoveSpeed * strafe);
        }

        if (vertical != 0)
        {
            var moveSpeed = vertical > 0 ? forwardMoveSpeed : backwardMoveSpeed;
            characterController.SimpleMove(transform.forward * moveSpeed * vertical);
        }
    }
}
