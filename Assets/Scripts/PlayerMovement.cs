using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Vector2 movement;
    public float moveSpeed;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    public float gravity;
    public bool isGrounded;
    private Vector3 velocity;
    Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (characterController.isGrounded && velocity.y < 0) {
            velocity.y = -1;
        }
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;
        animator.transform.localPosition = Vector3.zero;
        animator.transform.localEulerAngles = Vector3.zero;

        if (direction.magnitude > 0.1f) {
            animator.SetFloat("speed", moveSpeed);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); 
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        } else {
            animator.SetFloat("speed", 0);
        }
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
