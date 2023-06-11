using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class charControl : MonoBehaviour
{
    public Rigidbody charRb;
    public Vector2 moveVal;
    public float moveSpeed = 1;
    public Vector3 jumpVal;
    public float jumpForce = 10;

    private void Awake()
    {
        charRb = GetComponent<Rigidbody>();
    }

    public void moving(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            moveVal = value.ReadValue<Vector2>();
        }

        if (value.canceled)
        {
            moveVal = value.ReadValue<Vector2>();
        }
    }

    public void jump(InputAction.CallbackContext value)
    {
        if (value.performed)
        {
            Debug.Log("zýpla");
            charRb.AddForce(jumpForce*Vector3.up,ForceMode.Impulse);
        }
        
    }
}
