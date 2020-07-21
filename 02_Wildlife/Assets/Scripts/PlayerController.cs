using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;

    public float xRange = 15f;

    public GameObject projectilePrefab;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*Time.deltaTime*speed*horizontalInput);

        if (transform.position.x < -xRange)
        {
            //Se sale a izquierdas de la pantalla
            transform.position = new Vector3(-xRange, 
                transform.position.y, 
                transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            //Se sale a derechas de la pantalla
            transform.position = new Vector3(xRange,
                transform.position.y,
                transform.position.z);
        }
        
        //Acciones del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Si entramos aquí, hay que lanzar un proyectil
            Instantiate(projectilePrefab, 
                transform.position,
                projectilePrefab.transform.rotation);
        }
        
        
        
        
    }

    
}
