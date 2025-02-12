﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float LerpSpeed;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;  
    }

    
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position+offset, LerpSpeed);
    }
}
