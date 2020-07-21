using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(30, 0, 10);

    //private Vector3 playerPreviousPos = Vector3.zero;

    //private float distance = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 offset = plane.transform.position - playerPreviousPos;
        if(offset.magnitude < 0.5f){return;}
        
        offset.Normalize();*/
        transform.position = plane.transform.position + offset;
        /*
        transform.LookAt(plane.transform.position);
        playerPreviousPos = plane.transform.position;*/
    }
}
