using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GenerateWalls : MonoBehaviour
{
    public GameObject wall;
    public GameObject cone;
    private int number1;
    private int number2;
    private int resultado;

    private string[] calculo = new string[] { "3+5", "7+1", "6x2", "10x4", "2+3", "8-4", "5x3", "12/3", "9+6", "4-2", "7x2", "10/5", "6+4", "8-2", "3x4", "9/3", "5+2", "7-3", "2x5", "10/2" };
    private string[] certo = new string[] { "8", "8", "12", "40", "5", "4", "15", "4", "15", "2", "14", "2", "10", "6", "12", "3", "7", "4", "10", "5" };
    private string[] errado = new string[] { "7", "9", "16", "20", "6", "2", "12", "3", "14", "3", "16", "3", "8", "4", "10", "2", "8", "2", "8", "3" };
    private float timer = 0;
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3.0f)
        {
            int randomIndex = UnityEngine.Random.Range(0, 20);
            string equation = calculo[randomIndex];
            string correctAnswer = certo[randomIndex];
            string wrongAnswer = errado[randomIndex];

            // Use the equation and answers to set the text on the conta GameObject

            timer = 0;
            GameObject leftWall = Instantiate(wall, new Vector3(-4.5f, 3, transform.position.z), Quaternion.Euler(0, 0, 0));
            GameObject rightWall = Instantiate(wall, new Vector3(4.5f, 3, transform.position.z), Quaternion.Euler(0, 0, 0));
            GameObject conta = Instantiate(wall, new Vector3(transform.position.x, 10, transform.position.z), Quaternion.Euler(0, 0, 0));
            GameObject cone1 = Instantiate(cone, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            //Alterar os valores dos números de acordo com o resultado:
            conta.GetComponentInChildren<TMPro.TextMeshPro>().text = equation;
            bool showCorrectAnswerOnLeftWall = UnityEngine.Random.Range(0, 2) == 0;

            if (showCorrectAnswerOnLeftWall)
            {
                leftWall.GetComponent<TMPro.TextMeshPro>().text = correctAnswer;
                rightWall.GetComponent<TMPro.TextMeshPro>().text = wrongAnswer;
                rightWall.GetComponent<Collider>().enabled = true;
                leftWall.GetComponent<Collider>().enabled = false;
            }
            else
            {
                leftWall.GetComponent<TMPro.TextMeshPro>().text = wrongAnswer;
                rightWall.GetComponent<TMPro.TextMeshPro>().text = correctAnswer;
                rightWall.GetComponent<Collider>().enabled = false;
                leftWall.GetComponent<Collider>().enabled = true;
            }
        }
    }
}

// actualWall possui WallCenter, WallLeftDoor e WallRightDoor, preciso que o Collider delas sejam ativados ou desativados de acordo com variáveis booleanas 1 ou 0
