﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveIndian : MonoBehaviour
{
    public float radius ;
    public float originSpeed ;
    public float slowSpeed ;
    private float speed ;
    private Vector3 totemPos ;
    private Vector3 totemRot ;
    private bool held ;
    private float angle ;

    private float spacePressedTime ;
    private float thresholdHeld ;


    public GameObject arrow ;
    public GameObject slash ;
    public GameObject fire ;
    private Vector3 firePos ;

    // Start is called before the first frame update
    void Start() {
        spacePressedTime = 0 ;
        thresholdHeld = .1f ;
        speed = originSpeed ;
        held = false ;

        firePos = fire.transform.position ;
    }

    // Update is called once per frame
    void Update() {
        angle += speed   ;

        float positionX = (radius * Mathf.Cos(Mathf.Deg2Rad * angle));
        float positionZ = (radius * Mathf.Sin(Mathf.Deg2Rad * angle));
    
        transform.position = new Vector3(positionX, 1, positionZ);
        transform.Rotate(0, - speed, 0);

        if (Input.GetKeyUp("space")){
            speed = speed > 0 ? originSpeed : - originSpeed ;
            held = false ;
        }

        if (Input.GetKeyDown("space")){
            speed *= -1 ;

            kickTotem();

            // Instantiate(slash);

            if (!held){
                spacePressedTime = Time.timeSinceLevelLoad ;
                held = true ;
            }
        }

        if (Input.GetKey("space") && held) {
            if (Time.timeSinceLevelLoad - spacePressedTime >= thresholdHeld && Time.frameCount % 15 == 0) {
                speed = speed > 0 ? slowSpeed : - slowSpeed ;

                Vector3 dir = firePos - transform.position ;
                dir.y = 0 ;
                dir = dir.normalized ;
                
                GameObject arrow_ = Instantiate(arrow, transform.position, Quaternion.identity) ;
                // Debug.DrawRay(transform.position, dir * 1000, Color.blue, 1f);
                Quaternion rotation = Quaternion.LookRotation(dir, transform.up) ;
                arrow_.transform.rotation = rotation ;
                arrow_.GetComponent<Rigidbody>().AddForce(dir * 1000);
            }
        }
    }


    void kickTotem(){
        RaycastHit hit;
        Vector3 dir = new Vector3(transform.TransformDirection(Vector3.forward).z, 0,  - transform.TransformDirection(Vector3.forward).x);
        // Debug.DrawRay(transform.position, dir * 1000, Color.red, 5f);

        if (Physics.Raycast(transform.position, dir * 100, out hit, 100.0f)){
            if (hit.transform.tag == "totem")  {
                Debug.Log("slashed totem");

                Destroy(hit.collider.gameObject);
            }
        }
    }
}
