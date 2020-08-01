using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIScript : MonoBehaviour
{

    
    public Text debugText;

    public Transform target;

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
        float remainDist = Vector3.Distance(transform.position, target.position);

        debugText.text = remainDist.ToString();

        if (isWalk)
        {
            aiWalkDest();
        }
        else
        {
            aiStop();
        }

        if(remainDist < 1)
        {
            aiStop();
        }

        
    }

    public void aiWalkDest()
    {
        agent.SetDestination(target.position);
    }

    public void aiStop()
    {
        isWalk = false;
        agent.SetDestination(transform.position);
    }

    public void aiAtDest()
    {
        //BlaBla
    }

    public void aboutSpill()
    {
        //Momentum
    }

    public void Spilled()
    {
        //Bruh
    }

}
