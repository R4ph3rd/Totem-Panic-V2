using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TotemObject_ ;

public class WaveSpawner : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject totem_bad ;
   public Transform firePos ;
   public float delayWaves = 20f ;
   private float countdown = 2f ;
   public int nb_totems = 3 ;
    public ArrayList totemsAlive ;

    void Start(){
        totemsAlive = new ArrayList();

        // foreach ()
    }

   void Update(){
       if ( countdown <= 0f){
           newWave();
           countdown = delayWaves ;
       }

       countdown -= Time.deltaTime ;
   }

   void newWave(){
       nb_totems ++ ;

       for ( int i = 0 ; i < nb_totems ; i ++ ){
           spawnTotem();
       }

       Debug.Log("new totem wave !");
   }

   void spawnTotem(){
        TotemObject totem = new TotemObject(firePos.position, "id");
        GameObject Totem = Instantiate(totem_bad, totem.position, totem.rotation);
        
        Totem.GetComponent<MoveAround>().angle = totem.angle ;
        Totem.GetComponent<MoveAround>().radius = totem.radius ;

   }
}


