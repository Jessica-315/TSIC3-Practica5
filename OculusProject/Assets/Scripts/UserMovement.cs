using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovement : MonoBehaviour
{
    private Transform userPos;
    private float speed = 4.0f;
    private float rotationSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        userPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    userPos.position.Set(0.0f, 0.0f, 0.0f);
        //}
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        userPos.position = userPos.position + movementDirection * speed * Time.deltaTime;

        userPos.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
    }
}
