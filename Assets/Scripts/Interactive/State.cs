using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public float Speed = 1.0f;
    public bool _isActive;
    
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        SwitchMove();
    }

    public void SwitchState()
    {
        _isActive = !_isActive;

        SwitchMove();
    }

    void SwitchMove()
    {
        if (_isActive)
        {
            _animator.speed = Speed;
        }
        else
        {
            _animator.speed = 0;
        }
    }

    public bool IsActive()
    {
        return _isActive;
    }
}
