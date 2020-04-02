using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickTotem : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime ;
    void Start()
    {
        // arrow = GetComponent<GameObject> ;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("totem")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
