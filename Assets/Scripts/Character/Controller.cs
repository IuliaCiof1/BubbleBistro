using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    #region - Declarations
    public Camera playerCamera;
    CharacterController characterController;

    #region - Movement

    #region - Basic Movement
    public float walkSpeed = 4f;
    public float runSpeed = 5f;
    public float jumpPower = 6f;
    public float gravity = 20f;
    #endregion

    #region - States
    public bool isMoving = false;
    bool isRunning = false;
    public bool canMove = true; // Pentru cinematic-uri pe asta il setam pe false
    private bool canJump = true;
    #endregion

    #region - Sound
    public AudioClip[] Footstep;
    #endregion
    #endregion

    #region - Camera
    public float lookSpeed = 2f;
    public float lookXLimit = 80f;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    private Vector3 previousPosition;
    private float accumulatedDistance = 0f;
    public float footstepDistance = 1.0f;

    #endregion

    #region - Animation
    //[SerializeField] private Animator animator;
    #endregion
    #endregion

    #region - Methods
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        SetMovement(true);
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        isMoving = (curSpeedX != 0 || curSpeedY != 0);

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded && canJump)
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

        // PlayFootstepSound();
    }

    void PlayFootstepSound()
    {

        float distanceMoved = Vector3.Distance(previousPosition, transform.position);
        accumulatedDistance += distanceMoved;

        if (accumulatedDistance >= footstepDistance && isMoving && characterController.isGrounded)
        {
            SoundFXManager.instance.PlaySoundFXClips(Footstep, transform, 1f);
            accumulatedDistance = 0f;
        }

        previousPosition = transform.position;
    }

    void HandleRotation()
    {
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    public void SetMovement(bool state)
    {
        canMove = state;
        if (state)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    #endregion
}