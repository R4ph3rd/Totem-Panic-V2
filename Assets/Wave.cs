using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Waves_ {

    public class Wave {
        // Start is called before the first frame update
        public int good, bad, sticky ;
        public float start_angle ;
        public int[] repartition ;

        public Wave(int good, int bad, int sticky, float startangle, int[] repartition){
            this.good = good ;
            this.bad = bad ;
            this.sticky = sticky ;
            this.start_angle = startangle ; 
            this.repartition = repartition ;
        }
    }
}
