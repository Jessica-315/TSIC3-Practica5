using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class UserWinOrLose : MonoBehaviour
{
    public GameObject canvas;
    public GameObject textWin;
    public GameObject textLose;
    public GameObject button;

    private void OnTriggerEnter(Collider other)// Poner un box collider para detectar al jugador y pueda perseguirlo el enemigo
    {
        Debug.Log("Llegaste a la meta, ¡ganaste!");
        canvas.SetActive(true);
        textWin.SetActive(true);
        button.SetActive(true);
    }

    public void reiniciarEscena()
    {
        SceneManager.LoadScene(0);
    }
}
