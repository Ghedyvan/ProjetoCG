using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;

public class ObstacleBehavior : MonoBehaviour
{
    private float speed = -0.5f;
    private string pontosString;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed);

        if(transform.position.z < -17.0f)
        {
            ScoreManager.instance.AddScore(25);
            Destroy(this.gameObject);
        }
    }
}
