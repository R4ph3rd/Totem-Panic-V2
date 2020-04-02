using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // public ArrayList<object> totems = new ArrayList<object>();
    public GameObject bad_totem ;
    private int i = 0 ;
    

    void Start(){

    }

    void Update() {
        // if (totems.size == 0) {
        //     Delay(1);
        //     i ++ ;
        //     newWave(i);
        // }
    }

    void endGame(){
        // Draw.Debug("game over looser");
    }

    IEnumerator Delay(float time){
        yield return new WaitForSeconds(time);
    }
}
