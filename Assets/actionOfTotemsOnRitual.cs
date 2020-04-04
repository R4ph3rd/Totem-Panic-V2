using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionOfTotemsOnRitual : MonoBehaviour
{
    // Start is called before the first frame update
    private float timestamp ;
    public float threshold = 0;
    ParticleSystem.EmissionModule emission ;
    void Start()
    {
        timestamp = Time.timeSinceLevelLoad ;   
        emission = GetComponent<ParticleSystem>().emission ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad  - timestamp > threshold){
            timestamp = Time.timeSinceLevelLoad ;
            GameObject[] totems = GameObject.FindGameObjectsWithTag("totem");
            
                    
            foreach(GameObject totem in totems){
                if (!totem.GetComponent<TotemInstance>().polarity){
                    emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constantMax - 0.05f);
                } else {
                    emission.rateOverTime = new ParticleSystem.MinMaxCurve(emission.rateOverTime.constantMax + 0.05f);
                }
                    Debug.Log(emission.rateOverTime);
            }
        }
    }
}
