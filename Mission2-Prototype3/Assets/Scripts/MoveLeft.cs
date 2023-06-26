using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveLeft : MonoBehaviour
{
    public float speed; 
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
