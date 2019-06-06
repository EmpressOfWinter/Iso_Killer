using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }


   void Update()
    {
        
            transform.position += new Vector3(0,4,0) * Time.deltaTime;

    }
}
