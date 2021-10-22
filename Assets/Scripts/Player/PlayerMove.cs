using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 10.0f;
    public float SpeedRotate = 5.0f;
    public float ForceJump = 10.0f;
    public float Gravity = -9.0f;

    private CharacterController _characterController;
    private Vector3 _vectorMove;
    private float _valueJump;
    private bool _isGrounded;
    
    private bool _move;
    
    void Start()
    {
        _vectorMove = Vector3.zero;
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Drop();
        InputKey();
        Move();
    }
    
    void Drop()
    {
        _isGrounded = _characterController.isGrounded;
        _valueJump -= Gravity * Time.deltaTime;
        
        if (_isGrounded && _valueJump < 0.0f)
        {
            _valueJump = -Gravity * Time.deltaTime;
        }
    }

    void InputKey()
    {
        _vectorMove = transform.forward * Input.GetAxis("Vertical") * Speed;
        _vectorMove += transform.right * Input.GetAxis("Horizontal") * Speed;

        if (Input.GetKeyDown("space"))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (_isGrounded)
        {
            _valueJump += ForceJump;
        }
    }

    void Move()
    {
        RotationAxis();
        _vectorMove.y = _valueJump;
        _characterController.Move(_vectorMove * Time.deltaTime);
    }

    void RotationAxis()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * SpeedRotate, Space.World);
    }
}
