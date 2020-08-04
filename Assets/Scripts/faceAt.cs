using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceAt : MonoBehaviour
{

    public GameObject lookAtThis;

    // Update is called once per frame
    void Update()
    {
        float x = transform.eulerAngles.x;
        float z = transform.eulerAngles.z;
    }

    private void LateUpdate()
    {
        transform.LookAt(lookAtThis.transform);
    }
}
