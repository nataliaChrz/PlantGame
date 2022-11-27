using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool CanMove { get; private set; } = true;
    private bool isSprinting => canSprint && Input.GetKey(sprintKey);

    [Header("Controls")]
    [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;


    [Header("Function Options")]
    [SerializeField] public bool canSprint = true;


    [SerializeField] public bool canUseHeadbob = true;
    [SerializeField] public bool useFootsteps = true;

    [Header("Headnob Parameters")]
    [SerializeField] public float walkBobSpeed = 14f;
    [SerializeField] public float walkBobAmount = 0.05f;
    [SerializeField] public float sprintBobSpeed = 17f;
    [SerializeField] public float sprintBobAmount = 0.1f;
    private float defultYPos = 0;
    private float timer;

    [Header("Footsteps Parameters")]
    [SerializeField] public float baseStepSpeed = 0.5f;
    [SerializeField] public float sprintStepMultipler = 0.7f;
  
    private float footstepTimer = 0;
    private float GetCurrentOffset => isSprinting ? baseStepSpeed * sprintStepMultipler : baseStepSpeed;

    [Header("Movement Parameters")]
    [SerializeField] public float walkSpeed = 5.0f;
    [SerializeField] public float sprintSpeed = 8.0f;
    [SerializeField] public float gravity = 30.0f;


    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] public float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] public float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] public float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] public float lowerLookLimit = 80.0f;

    private Camera playerCamera;
    private CharacterController characterController;

    private Vector3 moveDirection;
    private Vector2 currentInput;

    private float rotationX = 0;

    public void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        defultYPos = playerCamera.transform.localPosition.y;

        Cursor.visible = false;
    }

    public void Update()
    {
        if (CanMove)
        {
            HandleMovementInput();
            HandleMouseLook();

            ApplyFinalMovement();
        }

        if (canUseHeadbob)
            HandleHeadbob();

        if (useFootsteps)
            HandleFootsteps();
    }

    private void HandleFootsteps()

    {
        if (!characterController.isGrounded) return;

        if (currentInput == Vector2.zero) return;

        footstepTimer -= Time.deltaTime;

        
    }

    private void HandleHeadbob()
    {
        if (!characterController.isGrounded) return;

        if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (isSprinting ? sprintBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defultYPos + Mathf.Sin(timer) * (isSprinting ? sprintBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z);
        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), (isSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLook()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }




    private void ApplyFinalMovement()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
