using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(0,180)]
    public float moveSpeed, rotateSpeed, force;

    public bool usePhysicsEngine; 
    
    private Rigidbody _rigidbody;

    private float verticalInput, horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovePlayer();
        
        KeepPlayerInBounds();
        


    }

    void MovePlayer()
    {
        if (usePhysicsEngine)
        {
            //Si se utiliza la física
            //AddForce sobre el rigidbody
            //AddTorque sobre el rigidbody 
            _rigidbody.AddForce(Vector3.forward*Time.deltaTime*force*verticalInput, ForceMode.Force);
            _rigidbody.AddTorque(Vector3.up*horizontalInput*force*Time.deltaTime, ForceMode.Force);        
        }
        else
        {
            //Si no utilizáis la física
            //Translate sobre el transform -> para mover
            //Rotate sobre el transform -> para rotar

            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * verticalInput);
            transform.Rotate(Vector3.up * horizontalInput * rotateSpeed * Time.deltaTime);
        }
    }

    void KeepPlayerInBounds()
    {
        //TODO: Refactorizar la posición límite en una variable
        if (Mathf.Abs(transform.position.x)>=24 || Mathf.Abs(transform.position.z)>=24)
        {
            _rigidbody.velocity = Vector3.zero;
            if (transform.position.x > 24)
            {
                transform.position = new Vector3(24, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -24)
            {
                transform.position = new Vector3(-24, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 24);
            }
            if (transform.position.z < -24)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -24);
            }
            
        } 
    }
    
    
}
