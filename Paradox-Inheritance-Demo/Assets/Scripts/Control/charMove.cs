using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpForce;
    private Animator charAnim;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    public bool isGrounded;
    private void Start()
    {
        charAnim = GetComponent<Animator>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (move.z < 0)
        {
            charAnim.SetFloat("vertical",1);
            charAnim.SetFloat("movement", 1);
        }
        else if (move.z > 0)
        {
            charAnim.SetFloat("movement", 1);
            charAnim.SetFloat("vertical",-1);
        }
        else
        {
            charAnim.SetFloat("movement", 0);
            charAnim.SetFloat("vertical", 0);
        }

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            if (charAnim.GetFloat("movement") == 1)
            {
                if (charAnim.GetBool("sprint"))
                {
                    charAnim.SetBool("jumpSprint", true);
                }
                else
                {
                    charAnim.SetBool("jumpWalk", true);
                }
            }

            if (charAnim.GetFloat("movement") == 0)
            {
                charAnim.SetBool("jump", true);
            }
        }

        else if (!isGrounded){
            charAnim.SetBool("jump", false);
            charAnim.SetBool("jumpWalk", false);
            charAnim.SetBool("jumpSprint", false);
        }

        if (Input.GetKey(KeyCode.LeftShift) && !charAnim.GetBool("weaponAimIdle") && charAnim.GetFloat("movement") == 1)
        {
            speed = 3;
            charAnim.SetBool("sprint", true);
        }

        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 1.5f;
            charAnim.SetBool("sprint",false);
            
        }
    }
}
 