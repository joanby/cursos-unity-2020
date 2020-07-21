using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    
    //OnTriggerEnter se llamará automáticamente cuando
    //un objeto físico etre dentro del trigger del Game Object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            //El animal choca contra un proyectil
            Destroy(this.gameObject);//Destruye el animal
            Destroy(other.gameObject); //Destruye lo otro
        }
        
    }


}
