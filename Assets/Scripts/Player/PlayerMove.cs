using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 10.0f;
    public float SpeedRotate = 5.0f;
    public float ForceJump = 250.0f;

    public GameObject Model;

    private Animator _animator;
    private Rigidbody _rb;
    private Vector3 _vectorMove;
    private float _valueJump;
    private bool _isGrounded;
    
    private bool _move;
    
    void Start()
    {
        _animator = Model.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _vectorMove = Vector3.zero;
    }

    void Update()
    {
        InputKey();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void InputKey()
    {
        if (Physics.Raycast(_rb.position, Vector3.down, 1.01f))
        {
            _animator.SetBool("Ground", true);
            
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        Invoke("OffGround", 1.0f);
        _animator.SetTrigger("Jump");
        _rb.AddForce(Vector3.up * ForceJump);
    }

    void OffGround()
    {
        _animator.SetBool("Ground", false);
    }

    void Move()
    {
        RotationAxis();
        
        _vectorMove = transform.forward * Input.GetAxis("Vertical") * Speed;
        _vectorMove += transform.right * Input.GetAxis("Horizontal") * Speed;
        
        _animator.SetFloat("Z", Input.GetAxis("Vertical"));
        _animator.SetFloat("X", Input.GetAxis("Horizontal"));
        _rb.MovePosition(_rb.position + _vectorMove * Time.deltaTime);
    }

    void RotationAxis()
    {
        _rb.MoveRotation(_rb.rotation * Quaternion.Euler(0.0f, Input.GetAxis("Mouse X") * SpeedRotate, 0.0f));
    }
}
