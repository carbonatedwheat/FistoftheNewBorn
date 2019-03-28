using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    /*
    IMPORTANT:
    Pair this with an empty GameObject in a scene to act
    as a general "Damage Manager" for the entire scene
    */

    public float Light;
    public float Heavy;
    public float enemy; //generic enemy damage values
    public float spiderStab, samuraiAntSlash,
        spellingBlockSpell; //Spider stabbing, samurai ant slash, and Spelling Block Spell attack values
   
    //adjust values as you see fit

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
