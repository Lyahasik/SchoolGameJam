using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject ModelMesh;
    public List<Material> Colors;
    
    private int _indexColor = 0;
    private Renderer _rendererModel;
    
    // Start is called before the first frame update
    void Start()
    {
        _rendererModel = ModelMesh.GetComponent<Renderer>();
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
            
            _rendererModel.material = Colors[0];
        }
        else
        {
            _indexColor = indexColor;
            
            _rendererModel.material = Colors[indexColor];
        }
    }
}
