using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewindScript : MonoBehaviour
{

    Rewinder playerRewinder;

    public bool isRewinding = false;

    public bool ableToRewind;

    List<Vector3> positions;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



        playerRewinder = GameObject.FindGameObjectWithTag("Player").GetComponent<Rewinder>();

        if(playerRewinder.rewindLimit >= 50)
        {
            ableToRewind = true;
        }

        else if(playerRewinder.rewindLimit <= 0)
        {
            ableToRewind = false;
        }

        if (!ableToRewind)
        {
            playerRewinder.rewindLimit += 2f;
        }


        if (Input.GetMouseButtonDown(1) && playerRewinder.rewindLimit > 0&&ableToRewind)
        {
            StartRewind();
        }
        if (Input.GetMouseButtonUp(1))
        {
            StopRewind();
        }
        


    }

    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    public void Record()
    {
        positions.Insert(0, transform.position);
    }

    public void Rewind()
    {
        if (positions.Count > 0)
        {
            playerRewinder.rewindLimit -= 1f;
            transform.position = positions[0];
            positions.RemoveAt(0);
            
        }
        else
        {
            StopRewind();
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rigidbody.isKinematic = true;
    }

    public void StopRewind()
    {
        
        
        isRewinding = false;
        rigidbody.isKinematic = false;
    }
}
