using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class simpleCamera : MonoBehaviour
{
    //Look duration on AI
    float lookEndAT = 3f;


    //Player Transform
    public Transform playerBody;


    public float sensitivity;

    PlayerItem playeritem;

    tableState customer;

    customerData Customerdata;

    Camera cam;

    float xRotation;

    Transform aiBody;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        playeritem = GetComponent<PlayerItem>();

        Customerdata = FindObjectOfType<customerData>();

        //Lock cursor in the middle and make it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {

        

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
            if (hit.collider.gameObject.CompareTag("customer"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    customer = hit.collider.GetComponent<tableState>();
                    if(playeritem.food && customer.isHungry)
                    {
                        Debug.Log("Makan uhuy!");
                        Customerdata.satisfy += 1;
                        customer.actionLimit = 30;

                        playeritem.food = false;

                        customer.isHungry = false;
                        customer.isThirsty = false;
                        customer.actionIndex = 0;

                        customer.timer = 0;
                        customer.timeLimit = Random.Range(10, 40);
                    }

                    else if (playeritem.water && customer.isThirsty)
                    {
                        Debug.Log("Minum Hayuk!");
                        Customerdata.satisfy += 1;
                        customer.actionLimit = 30;

                        playeritem.water = false;

                        customer.isHungry = false;
                        customer.isThirsty = false;
                        customer.actionIndex = 0;

                        customer.timer = 0;
                        customer.timeLimit = Random.Range(10, 40);
                    }

                    else
                    {
                        Debug.Log("Invalid Input!!!");
                        Customerdata.unsatisfy += 1;
                        customer.actionLimit = 30;

                        customer.isHungry = false;
                        customer.isThirsty = false;
                        customer.actionIndex = 0;

                        customer.timer = 0;
                        customer.timeLimit = Random.Range(10, 40);
                    }
                    

                }
            }
          
        }

     

    }

   
  


}
