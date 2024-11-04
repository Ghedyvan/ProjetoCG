using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehavior : MonoBehaviour
{
    private float speed = -0.3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed);

        if(transform.position.z < -17.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
