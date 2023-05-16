using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(0, 4, 1);
        transform.localScale = Vector3.one * 2.2f;
        
        Material material = Renderer.material;
        
        material.color = new Color(.1f, .5f, .9f, .5f);
    }
    
    void Update()
    {
        transform.Rotate(5.0f * Time.deltaTime, 0.2f, 0.15f);
    }
}
