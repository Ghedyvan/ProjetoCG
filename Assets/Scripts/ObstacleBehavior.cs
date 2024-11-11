using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ObstacleBehavior : MonoBehaviour
{
    private float speed = -0.3f;

    void Update()
    {
        // Verifica se o GameManager existe e se o jogo não está em Game Over
        if (GameManager.Instance == null || !GameManager.Instance.isGameOver)
        {
            transform.position += new Vector3(0, 0, speed);

            if(transform.position.z < -17.0f)
            {
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddPoints(250);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
