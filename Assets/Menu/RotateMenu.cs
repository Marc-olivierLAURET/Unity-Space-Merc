using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    public Transform shape;
    public Vector3 MainPosition;
    public Vector3 SecondPosition;
    public float Speed = 5;

    private int status = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (status == 0) {
            shape.position = Vector3.Lerp(shape.position, MainPosition, Time.deltaTime * Speed);
        } else {
            shape.position = Vector3.Lerp(shape.position, SecondPosition, Time.deltaTime * Speed);
        }
    }

    public void Set_Status(int value) {
        status = value;
    }
}
