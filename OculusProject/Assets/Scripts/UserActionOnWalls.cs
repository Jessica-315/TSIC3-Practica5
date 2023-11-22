using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.AI;

public class UserOn : MonoBehaviour
{

    //private Transform user;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("--Atravesando pared!!!!!!!!!!!");

        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Atravesando pared!!!!!!!!!!!");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("--Atravesando pared!!!!!!!!!!!");

        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Atravesando pared!!!!!!!!!!! Colision");
            //user = GetComponent<Transform>();
            //user.transform.position = user.transform.position;
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
