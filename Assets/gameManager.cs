using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TotemObject_ ;
using UnityEngine.SceneManagement ;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // public ArrayList<object> totems = new ArrayList<object>();
    static public List<TotemObject> totemsAlive ; // to check how many totems are currently in game
    static public bool gameHasEnded = false ;

    void Start(){
        totemsAlive = new List<TotemObject>();
    }

    void Update() {
        // if (totems.size == 0) {
        //     Delay(1);
        //     i ++ ;
        //     newWave(i);
        // }
    }

    public static void EndGame(){
        if (!gameHasEnded){
            Debug.Log("game over looser");
            gameHasEnded = !gameHasEnded ;  


            Time.timeScale = 0 ;
            ShowEnd();
            Restart();
        }
    }

    public static void Restart(){

        if (Time.timeScale == 0){
            if (Input.GetKeyDown("space")){
                gameHasEnded = false ;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                // Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public static void ShowEnd(){
        GameObject msg = new GameObject("restart");
        Text text = msg.AddComponent<Text>();
        text.text = "Press spacebar to restart";
    }

    public static void addTotemToList(TotemObject totem){
        totemsAlive.Add(totem);
    }

    public static void removeTotemFromList(int id) {
        totemsAlive.Remove(
            totemsAlive.Find( totem => totem.id == id )
        );
        Debug.Log("kicked totem" + totemsAlive.Count);
    }

    public static IEnumerator Delay(float time){
        yield return new WaitForSeconds(time);
    }
}
