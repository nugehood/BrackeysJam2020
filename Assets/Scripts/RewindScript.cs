using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindScript : MonoBehaviour
{

    public bool isRewinding = false;

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
        if (Input.GetKeyDown(KeyCode.Return))
        
            StartRewind();
        if (Input.GetKeyUp(KeyCode.Return))
            StopRewind();
        
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
