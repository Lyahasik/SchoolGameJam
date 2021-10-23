using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Animator AnimatorPlatform;
    public State PrefabState;
    
    private bool _isTrigger = false;
    private bool _isOn = false;

    void Update()
    {
        InputKey();
    }

    void InputKey()
    {
        if (_isTrigger && Input.GetMouseButtonDown(0))
        {
            _isOn = !_isOn;
            AnimatorPlatform.SetBool("On", _isOn);
            
            PrefabState.SwitchState();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isTrigger = false;
        }
    }
}
