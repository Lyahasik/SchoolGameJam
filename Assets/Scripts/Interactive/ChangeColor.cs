using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameManager GameManager;
    
    public enum ColorPlayer
    {
        green = 1,
        red = 2
    }

    public ColorPlayer PlayerColor;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().ChangeColor((int)PlayerColor);
            GameManager.ChangeCollision((int)PlayerColor);
        }
    }
}
