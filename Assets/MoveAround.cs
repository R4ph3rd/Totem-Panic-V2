using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public float radius ;
    public float speed ;
    public bool sticky ;
    private float angle ;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {
        if (!sticky){
            angle += speed   ;

            float positionX = (radius * Mathf.Cos(Mathf.Deg2Rad * angle));
            float positionZ = (radius * Mathf.Sin(Mathf.Deg2Rad * angle));
     
            transform.position = new Vector3(positionX, 0, positionZ);
            transform.Rotate(0, - speed, 0);
        }
    }
}
