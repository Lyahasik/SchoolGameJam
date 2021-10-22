using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _indexColor = 0;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }

    public void ChangeCollision(int indexColor)
    {
        if (_indexColor == indexColor)
        {
            _indexColor = 0;
            
            OnColiisionGreen();
            OnColiisionRed();
        }
        else if (indexColor == 1)
        {
            _indexColor = indexColor;
            
            OnColiisionGreen();
            OffColiisionRed();
        }
        else if (indexColor == 2)
        {
            _indexColor = indexColor;
            
            OffColiisionGreen();
            OnColiisionRed();
        }
    }
    
    private void OffColiisionGreen()
    {
        Physics.IgnoreLayerCollision(6, 7, true);
    }
    
    private void OnColiisionGreen()
    {
        Physics.IgnoreLayerCollision(6, 7, false);
    }

    private void OffColiisionRed()
    {
        Physics.IgnoreLayerCollision(6, 8, true);
    }
    
    private void OnColiisionRed()
    {
        Physics.IgnoreLayerCollision(6, 8, false);
    }
}
