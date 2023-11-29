using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravity = 9.81f;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                float jumpSpeed = 5.0f;
                Vector3 jumpVelocity = Vector3.up * jumpSpeed;
                characterController.Move(jumpVelocity * Time.deltaTime);
            }
        }
        else
        {
            Vector3 gravityVector = Vector3.down * gravity * Time.deltaTime;
            characterController.Move(gravityVector);
        }
    }
}
