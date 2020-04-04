using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText ; 
    public Text highScore ;

    public float score = 0f ;
    void Start()
    {
        scoreText.text = "0" ;
    }

    // Update is called once per frame
    void Update()
    {
        // score += 2f ;
        // scoreText.text = score.ToString() ;
    }
}
