using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class simpleCamera : MonoBehaviour
{
    //Look duration on AI
    float lookEndAT = 3f;

    //Array of AI
    AIScript[] AI;

    //Player Transform
    public Transform playerBody;

    public float sensitivity;

    Camera cam;

    float xRotation;

    Transform aiBody;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();


        //Lock cursor in the middle and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {

        //Find object that has the script in Scene!
        AI = FindObjectsOfType<AIScript>();

        //Checking every AI in scenes
        foreach(AIScript waitress in AI)
        {
            //When one waitress is about to spill
            if (waitress.isAboutSpill)
            {
                //Get AI body from the active one
                //Start Coroutine for lookin at ai
                aiBody = waitress.transform;
                StartCoroutine(lookAi(lookEndAT));
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


    IEnumerator lookAi(float delay)
    {
        playerBody.LookAt(aiBody.transform.position, Vector3.up);
        this.enabled = false;
        yield return new WaitForSeconds(delay);
        foreach (AIScript waitress in AI)
        {
            waitress.isAboutSpill = false;
        }
        this.enabled = true;


    }
  


}
