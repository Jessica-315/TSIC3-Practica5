using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public bool userDetect;
    public bool userLose;
    public bool enemyLose;
    public Transform user;// S�lo accedemos al contenido de Transform de la c�mara, si quisieramos acceder a todos los componentes ser�a GameObject en lugar de Transform
    private NavMeshAgent enemy;// Accedemos a la informaci�n del agente, es �ptimo y consume menos recursos esta forma (private en lugar de public)
    private Animator enemyAnimator; // Para ligar la m�quina de estados con este script
    private Transform enemyTransform;
    private int deadEnemyCount;
    public GameObject canvas;
    public GameObject textWin;
    public GameObject textLose;
    public GameObject boxLose;
    public GameObject button;
    //private GameObject enemyGO;// GameObject del enemigo

    private void OnTriggerEnter(Collider other)// Poner un box collider para detectar al jugador y pueda perseguirlo el enemigo
    {
        userDetect = true;
    }

    private void OnTriggerExit(Collider other)
    {
        userDetect = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();// Es la alternativa para la forma public, se accede al contenido NavMeshComponent
        enemyAnimator = GetComponent<Animator>(); // Alternativa private, �ptimo
        enemyTransform = GetComponent<Transform>();
        deadEnemyCount = 0;

        canvas.SetActive(false);
        textLose.SetActive(false);
        textWin.SetActive(false);
        boxLose.SetActive(false);
        button.SetActive(false);
        //enemyGO = GetComponent<GameObject>();
        //for (var i = 0; i < 1; i++)
        //{
        //    Instantiate(enemy, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (userDetect)
        {
            //Debug.Log(enemyAnimator.name);
            enemyAnimator.SetBool("Run", true);// La variable de la m�quina de estados para que cambie a correr es Run
            enemy.isStopped = false;
            enemy.destination = user.position;// El objetivo del agente es la posici�n del usuario

            //enemyAnimator.ResetTrigger("AttackTrigger");

            //if (enemyTransform.position.x == user.position.x && enemyTransform.position.z == user.position.z)
            //{
            //    //Debug.Log("Llega aquiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
            //    enemyAnimator.SetTrigger("AttackTrigger");
            //}

        }
        else
        {
            enemyAnimator.SetBool("Run", false);
            enemy.isStopped = true;
        }

        if (userLose)
        {
            Debug.Log("Colision con : Main camera");
            Debug.Log("�Te ataca el enemigo!");
            enemyAnimator.SetTrigger("AttackTrigger");
            Debug.Log("Perdiste");
            canvas.SetActive(true);
            textLose.SetActive(true);
            boxLose.SetActive(true);
            button.SetActive(true);
        }
        
        if(enemyLose)
        {
            Debug.Log("Colision con : Bullet");
            enemyAnimator.SetTrigger("HitFromPlayer");
            deadEnemyCount++;
            Debug.Log("Numero de enemigos muertos: " + deadEnemyCount);
            if (deadEnemyCount == 3)
            {
                Debug.Log("�Ganaste!");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            userLose = true;
            //Debug.Log("Colision con : Main camera");
            //Debug.Log("�Te ataca el enemigo!");
            //enemyAnimator.SetTrigger("AttackTrigger");
            //Debug.Log("Perdiste");
        }
        if (collision.gameObject.tag == "Bullet")
        {
            enemyLose = true;
            //Debug.Log("Colision con : Bullet");
            //deadEnemyCount++;
            //Debug.Log("Numero de enemigos muertos: " + deadEnemyCount);
        }
        //Debug.Log("�Te ataca el enemigo!");
        //enemyAnimator.SetTrigger("AttackTrigger");
        //Debug.Log("Perdiste");
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            userLose = false;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            enemyLose = false;
        }
    }
}
