using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class simpleCamera : MonoBehaviour
{

    AIScript[] AI;

    public Transform playerBody;

    public float sensitivity;

    Camera cam;

    float xRotation;

    Transform aiBody;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        
        AI = FindObjectsOfType<AIScript>();

        foreach(AIScript waitress in AI)
        {
            if (waitress.isSpill)
            {
                aiBody = waitress.transform;
                talkAI();
            }
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Ray ray;
        ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        

        if (Physics.Raycast(ray ,out hit, 5f))
        {
            if (hit.collider.gameObject.CompareTag("AI"))
            {
                
            }  
          
        }

     

    }

    public void talkAI()
    {
        playerBody.LookAt(aiBody.transform.position);
    }


}
