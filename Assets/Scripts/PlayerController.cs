using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    void Start()
    {
        
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.x > -5.5 && horizontalInput < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.Rotate(Vector3.down, turnSpeed * Time.deltaTime);
        } else if (transform.position.x < 5.5 && horizontalInput > 0) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Numero")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
