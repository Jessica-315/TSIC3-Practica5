using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;       // Modelo de la bala
    public Transform spawnPoint;    // Punto de donde sale la bala

    public float shotForce = 1500;  // Fuerza de disparo
    public float shotRate = 0.5f;   // Tiempo de espera para disparar otra vez

    private float shotRateTime = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > shotRateTime)
            {
                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);      // Se crea la bala en el spawn point
                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);   // Fuerza de disparo

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 2);  // Se destruye la bala después de 2 segundos
            }
        }
    }

}
