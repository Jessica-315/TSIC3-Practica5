using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomEnemies : MonoBehaviour
{

    public NavMeshAgent newEnemy;
    public Transform OriginalEnemyPos;
    public int numEnemies;
    private Vector3 pos;
    private Vector2 mm = new Vector2(-0.5f, 27.0f);// x = mínimo, y = máximo (Rango de ubicación en el eje X y Z del suelo en el que se aparecerán los enemigos)

    // Start is called before the first frame update
    void Start()
    {
        //newEnemy = GetComponent<NavMeshAgent>();
        for (int i = 0; i < numEnemies; i++)
        {
            pos.x = Random.Range(mm.x, mm.y); pos.y = OriginalEnemyPos.position.y; pos.z = Random.Range(mm.x, mm.y);
            Instantiate(newEnemy, pos, Quaternion.identity);
        }
        
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
