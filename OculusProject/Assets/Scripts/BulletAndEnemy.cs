using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAndEnemy : MonoBehaviour
{

    //public Animator enemyAnimator; // Para ligar la máquina de estados con este script
    //private int totalEnemies = 3;
    //private int deadEnemyCount = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //deadEnemyCount++;

            Debug.Log("¡Eliminaste un enemigo!");

            //if (deadEnemyCount == totalEnemies)
            //{
            //    Debug.Log("¡Ganaste!");
            //}
            //enemyAnimator.SetTrigger("HitFromPlayer");
            Destroy(other.gameObject, 1);
            
        }
    }
}
