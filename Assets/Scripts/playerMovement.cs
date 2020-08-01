using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{

    CharacterController characterController;

    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mov = transform.right * x + transform.forward * z;

        characterController.SimpleMove(mov * moveSpeed);
    }
}
