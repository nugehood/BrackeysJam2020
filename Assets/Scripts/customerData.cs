using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class customerData : MonoBehaviour
{



    public TMP_Text satisfyText, unsatisfyText;

    public int satisfy, unsatisfy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        satisfyText.text = satisfy.ToString();

        unsatisfyText.text = unsatisfy.ToString();

    }
}
