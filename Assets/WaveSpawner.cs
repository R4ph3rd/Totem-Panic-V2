using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TotemObject_ ;
using Waves_ ;

public class WaveSpawner : MonoBehaviour {
        // Start is called before the first frame update
    public GameObject totem_bad ;
    public GameObject totem_good ;
    public Transform firePos ;
    public float delayWaves = 3f ;
    private float countdown = 2f ;
    public int totemWave = - 1 ;

    static public Wave[] waves ;
    // static public List<TotemObject> totemsAlive ; // to check how many totems are currently in game

    void Start(){
        
        initializeWaves();
        // totemsAlive = new List<TotemObject>();
    }

    void Update(){
        if ( countdown <= 0f){
            newWave();
            countdown = delayWaves ;
        }

        if (gameManager.totemsAlive.Count == 0){
            countdown -= Time.deltaTime ;
        }
    }

    void newWave(){
        Debug.Log("new totem wave !");
        totemWave ++ ;

        if (totemWave > waves.Length){
            finalBoss();

        } else {
            for (int i = 0 ; i < waves[totemWave].repartition.Length ; i ++){
                for (int k = 0 ; k < waves[totemWave].repartition[i] ; k ++){
                    //determine if sticky or not
                    bool sticky = false ;
                    if (waves[totemWave].sticky > 0){
                        if (waves[totemWave].good + waves[totemWave].bad - i > waves[totemWave].sticky){
                            sticky = true ;
                            waves[totemWave].sticky -- ;
                        } else {
                            sticky = Random.Range(0, waves[totemWave].good + waves[totemWave].bad) < waves[totemWave].sticky ? true : false ;
                        }
                    }

                    //determine if we pick a good or bad one
                    bool polarity = false ;
                    if (waves[totemWave].good > 0){
                        polarity = Random.Range(0,1) > 0.5 ? false : true ;
                        if (polarity) {
                            waves[totemWave].good -- ;
                        }
                    }

                    //determine angle
                    float angle = (i * 360 / waves[totemWave].repartition.Length) + (k * 13) ;

                    TotemObject totem = new TotemObject(firePos.position, i, angle, polarity, sticky);

                    spawnTotem(totem);
                }
            }
        }
    }

    void spawnTotem(TotemObject totem){
            // TotemObject totem = new TotemObject(firePos.position, i, false);
            GameObject Totem ;
            if (totem.polarity){
                Totem = Instantiate(totem_good, totem.position, totem.rotation);
            } else {
                Totem = Instantiate(totem_bad, totem.position, totem.rotation);
            }
            
            Totem.GetComponent<TotemInstance>().angle = totem.angle ;
            Totem.GetComponent<TotemInstance>().radius = totem.radius ;
            Totem.GetComponent<TotemInstance>().id = totem.id ;
            Totem.GetComponent<TotemInstance>().polarity = totem.polarity ;

            gameManager.addTotemToList(totem) ;

            // Debug.Log(totemsAlive.Count);
    }

    void finalBoss(){
        Debug.Log("final boss comming !");
    }

    public static void initializeWaves(){
        waves = new Wave[5] ;

        waves[0] = new Wave(1, 3, 0, 0, new int[] {1,1,1,1});
        waves[1] = new Wave(0, 5, 0, 0, new int[] {1,2,1,2});
        waves[2] = new Wave(1, 6, 0, 0, new int[] {1,2,1,2});
        waves[3] = new Wave(1, 8, 2, 0, new int[] {2,1,1,2,1,1});
        waves[4] = new Wave(6, 0, 6, 0, new int[] {1,1,1,1,1,1});
    }
}