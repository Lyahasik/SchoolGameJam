using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<Material> Colors;
    
    private int _indexColor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor(int indexColor)
    {
        if (_indexColor == indexColor)
        {
            _indexColor = 0;
            
            GetComponent<Renderer>().material = Colors[0];
        }
        else
        {
            _indexColor = indexColor;
            
            GetComponent<Renderer>().material = Colors[indexColor];
        }
    }
}
