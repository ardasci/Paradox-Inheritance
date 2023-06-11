using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class charControlRuntime : MonoBehaviour
{
    private charControl _input;
    private CharacterController _controller;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<charControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _controller.Move(new Vector3(_input.moveVal.x*_input.moveSpeed,0f,_input.moveVal.y*_input.moveSpeed));
    }
}
