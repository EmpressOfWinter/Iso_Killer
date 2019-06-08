using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private bool P_Movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        P_Movement = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(P_Movement)
        {
            //add a forward force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        }
        

        
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        Vector3 movement = new Vector3(moveHorizontal, 0, 0);

        rb.AddForce(movement * sidewaysForce*Time.deltaTime);
    }


    void OnCollisionEnter(Collision collisionInfo)
    {
       if (collisionInfo.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("hey a cube !");
            P_Movement = false;
        }
    }
}
