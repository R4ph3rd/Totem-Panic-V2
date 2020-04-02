using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  TotemObject_ {
    public class TotemObject {
        public float angle, radius ;
        public Vector3 position ;
        public Quaternion rotation ;
        public Transform firePos ;
        public string id ;

        public TotemObject(Vector3 firePos, string id){
            this.id = id ;
            this.angle = Random.Range(0, 360) ;
            this.radius = 5.72f ;
            this.position =  new Vector3(
                ((radius * Mathf.Cos(Mathf.Deg2Rad * angle))),
                0,
                (radius * Mathf.Sin(Mathf.Deg2Rad * angle))
            );

            Vector3 dir = firePos - this.position ;
            this.rotation = Quaternion.LookRotation(dir, new Vector3(0, 1, 0)) ;
        }
    }
}