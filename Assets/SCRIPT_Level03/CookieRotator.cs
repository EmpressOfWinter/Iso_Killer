﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieRotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 30, 10) * Time.deltaTime);

        if (transform.position.y<= -8)
        {
            Destroy(gameObject);
        }
    }
}
