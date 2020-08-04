using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class tableState : MonoBehaviour
{
    public bool isHungry, isThirsty, isAboutSpill, isSpilled;

    public int actionIndex;

    public float timer, timeLimit;

    public float actionLimit;

    customerData Customerdata;

    [Range(10, 60)]
    public float maxTimeLimit;

    public TMP_Text timerText;

    [Space]
    public SpriteRenderer mainSprite, iconSprite;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {

        timeLimit = Random.Range(10, maxTimeLimit);
        Debug.Log("Current Time Limit " + timeLimit);
        actionLimit = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        timerText.text = Mathf.RoundToInt(actionLimit).ToString();

        Customerdata = FindObjectOfType<customerData>();

        if(timer >= timeLimit&&actionIndex <= 0)
        {
            actionIndex = Random.Range(1, 3);
            timer = 0;
            timeLimit = Random.Range(10, maxTimeLimit);
            Debug.Log("Active Index: " + actionIndex);
        }

        if(actionLimit <= 0)
        {
            Customerdata.unsatisfy += 1;
            actionIndex = 0;
            timer = 0;
            actionLimit = 30;
            
            timeLimit = Random.Range(10, maxTimeLimit);
            Debug.Log("Active Index: " + actionIndex);
        }
        
        switch (actionIndex)
        {
            case 0:
                mainSprite.enabled = false;
                iconSprite.enabled = false;
                break;

            case 1:
                mainSprite.enabled = true;
                iconSprite.enabled = true;
                isHungry = true;
                isThirsty = false;
                hungry();
                break;
            case 2:
                mainSprite.enabled = true;
                iconSprite.enabled = true;
                isHungry = false;
                isThirsty = true;
                thirsty();
                break;
        }

        
    }

    public void hungry()
    {
        iconSprite.sprite = sprites[0];
        actionLimit -= 0.1f;
    }

    public void thirsty()
    {
        iconSprite.sprite = sprites[1];
        actionLimit -= 0.1f;
    }
}
