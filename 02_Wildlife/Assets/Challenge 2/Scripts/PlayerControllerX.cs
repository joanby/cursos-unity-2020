using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float fireRate = 1f;//Cada 1 segundo, el jugador puede lanzar 1 perro
    private float timeSinceLastFire = 0f; //Tiempo desde el último disparo
    
    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastFire > fireRate)
        {
            timeSinceLastFire = 0f;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
