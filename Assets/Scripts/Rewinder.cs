using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rewinder : MonoBehaviour
{

    public Slider rewindSlider;

    public float rewindLimit;

    public bool ableToRewind;

   
    // Update is called once per frame
    void Update()
    {
        rewindLimit = Mathf.Clamp(rewindLimit,0f, 50f);
        rewindSlider.value = rewindLimit;
       
        
    }
}
