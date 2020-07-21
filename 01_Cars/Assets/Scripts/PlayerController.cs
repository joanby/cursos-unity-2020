using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PROPIEDADES
    //[HideInInspector] 
    [Range(0, 20), 
     SerializeField,
     Tooltip("Velocidad lineal máxima del coche")]
    private float speed = 20f;

    [Range(0, 90), 
     SerializeField,
     Tooltip("Velocidad de giro máxima del coche")]
    private float turnSpeed = 45f;

    private float horizontalInput, verticalInput;
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // S = s0 + V*t*(direccion)
        transform.Translate(speed*Time.deltaTime*Vector3.forward*verticalInput);
        transform.Rotate(turnSpeed * Time.deltaTime * Vector3.up * horizontalInput);
    }
}
