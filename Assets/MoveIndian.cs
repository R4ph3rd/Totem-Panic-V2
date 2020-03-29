using System.Collections;
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

    // Start is called before the first frame update
    void Start() {
        spacePressedTime = 0 ;
        thresholdHeld = .1f ;
        speed = originSpeed ;
        held = false ;
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
            if (Time.timeSinceLevelLoad - spacePressedTime >= thresholdHeld) {
                speed = speed > 0 ? slowSpeed : - slowSpeed ;

                // Vector3 pos = transform.position ;
                GameObject fire = GameObject.FindWithTag("fire");

                // Instantiate(arrow, transform.position, transform.rotation) as GameObject ;
                // Physics.IgnoreCollision(arrow.GetComponent<Collider>(), fire.GetComponent<Collider>());
                // RigidBody arrow_ = (RigidBody)arrow_.GetComponent<Rigidbody>();
                // arrow_.AddForce()
            }
        }
    }


    void kickTotem(){
        // ArrayList totems = GameObject.FindGameObjectsWithTag("totem") ;

        RaycastHit hit;
        // Vector3 dir = Vector3.Cross(transform.TransformDirection(Vector3.forward), Vector3.up).normalized ;
        Vector3 dir = new Vector3(transform.TransformDirection(Vector3.forward).z, 0,  - transform.TransformDirection(Vector3.forward).x);
        Debug.DrawRay(transform.position, dir * 1000, Color.red, 5f);

        // foreach (GameObject totem in GameObject.FindGameObjectsWithTag("totem")){
            
        //     if (totem)
        // }

        if (Physics.Raycast(transform.position, dir * 100, out hit, 100.0f)){
            if (hit.transform.tag == "totem")  {
                Debug.Log("slashed totem");

                Destroy(hit.collider.gameObject);
            }
        }
    }
}
