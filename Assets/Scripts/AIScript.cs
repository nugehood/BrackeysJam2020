using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIScript : MonoBehaviour
{
    
    public Transform originalPos;

    [Header("For debugging ONLY!")]
    public Text debugText;
    public KeyCode walk, dest, spill, aboutspill;

    [Space]
    public Transform target;

    CustomersData customerdata;

    public bool isWalk, isDest, isSpill, isAboutSpill; 

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
    }

    // Update is called once per frame
    void Update()
    {

        customerdata = FindObjectOfType<CustomersData>();

        float remainDist = Vector3.Distance(transform.position, target.position);

        debugText.text = remainDist.ToString();

        if (Input.GetKeyDown(walk))
        {
            aiWalkDest();
        }

        if (Input.GetKeyDown(aboutspill))
        {
            isAboutSpill = true;
        }

        if (isWalk&&!isDest)
        {
            aiWalkDest();
        }
        else
        {
            aiStop();
        }
        
        if(remainDist < 1.9f&&!isDest)
        {
           
            aiStop();
            aiAtDest();
        }

        
    }

    //Make the AI walk to destination
    public void aiWalkDest()
    {
        agent.SetDestination(target.position);
        isDest = false;
    }

    //Stop the AI at current position
    public void aiStop()
    {
        isWalk = false;
        agent.SetDestination(transform.position);
    }

    //When AI at the destination
    public void aiAtDest()
    {
            customerdata.satisfy += 1;
            isWalk = true;
            target = originalPos;
    }

    //When AI about to spill the drinks
    public void aboutSpill()
    {
        //Momentum
    }

    //When AI already spilled the drinks
    public void Spilled()
    {
        customerdata.unSatisfy += 1;
    }

}
