using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomersData : MonoBehaviour
{
    public int satisfy;

    public int unSatisfy;

    public TMP_Text satisfyText, unSatisfyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        satisfyText.text = satisfy.ToString();
        unSatisfyText.text = unSatisfy.ToString();
    }
}
