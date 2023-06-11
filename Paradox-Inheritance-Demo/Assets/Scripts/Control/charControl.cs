using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charControl : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody charRb;
    private Animator charAnim;
    public Vector2 moveInput;
    public Vector3 currentMove;
    public float moveSpeed = 2;
    public float jumpForce = 4;
    public bool isMovePressed;
    public bool onGround;
    

    private void Start()
    {
        charRb = GetComponent<Rigidbody>();
        charAnim = GetComponent<Animator>();
    }
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.playerController.Movement.started += Move;
        playerInput.playerController.Movement.performed += Move;
        playerInput.playerController.Movement.canceled += Move;
    }

    void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        currentMove.x = moveInput.x;
        currentMove.z = moveInput.y;
        isMovePressed = moveInput.x != 0 || moveInput.y != 0;
    }

    private void FixedUpdate()
    {
        if (isMovePressed)
        {
            charRb.MovePosition(transform.position + currentMove * moveSpeed * Time.deltaTime);
        }
        if (moveInput.y == 0)
        {
            charAnim.SetFloat("movement", 0);
            charAnim.SetFloat("vertical", 0);
            charAnim.SetFloat("horizontal", 0);
        }
        else
        {
            charAnim.SetFloat("movement", 1);

            switch (moveInput.y)
            {
                case 1:
                    charAnim.SetFloat("vertical",1);
                    break;

                case -1:
                    charAnim.SetFloat("vertical", -1);
                    break;

                case 0:
                    break;
            }

            
        }
    }
    private void OnEnable()
    {
        playerInput.playerController.Enable();
    }

    private void OnDisable()
    {
        playerInput.playerController.Disable();
    }

    public void jump(InputAction.CallbackContext value)
    {
        if (value.performed && onGround)
        {
            charRb.AddForce(jumpForce*Vector3.up,ForceMode.Impulse);

        }
        
    }

    public void spirnt(InputAction.CallbackContext value)
    {
        if (value.performed && moveInput.y == 1)
        {
            moveSpeed = 3;
        }

        if (value.canceled)
        {
            moveSpeed = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "plane")
        {
            onGround = true;
            charAnim.SetBool("jump",false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "plane")
        {
            onGround = false;
            charAnim.SetBool("jump", true);
        }
    }
}
