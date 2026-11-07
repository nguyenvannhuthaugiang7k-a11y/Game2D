using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Weapon : MonoBehaviour
{   
    [SerializeField]
    private int rotateAround = 200;
    [SerializeField]
    private Vector3 rotationPoint = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = CalRotationAmount(Time.deltaTime);

        // chuyen dong quay quanh truc vector3.zero = vector3(0, 0, 0 )
        // forward = (0,0,1)
        transform.RotateAround(rotationPoint, Vector3.forward, rotationAmount);
    }

    private float CalRotationAmount(float delta)
    {
        return rotateAround * Time.deltaTime;
    }
}
