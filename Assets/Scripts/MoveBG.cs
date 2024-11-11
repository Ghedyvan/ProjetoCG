using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    private bool hasInstantiate = false;
    private float speed = -0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed);

        if(transform.position.z <= -10f)
        {
            Destroy(this.gameObject);
        }else if(transform.position.z <= 30f)
        {
            if(hasInstantiate == false)
            {
                hasInstantiate = true;
                GameObject obj = Instantiate(this.gameObject, new Vector3(transform.position.x, transform.position.y, 70f), Quaternion.Euler(0, 90, 0));
            }
        }
    }
}
