using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Joystick : MonoBehaviour
{
    [Header("CONTROLS")]
    public float speed;
    private Rigidbody rb;
    public Joystick joystick;

    public GameObject Joystick_Canvas;

    //start_Android specifics floats
    private float deltaX, deltaZ;
    private bool Joystick_Active;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Joystick_Canvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Joystick_Canvas.SetActive(true);

        //if the joystick is activated
        

            float moveHorizontalA = joystick.Horizontal;
            float moveVerticalA = joystick.Vertical;

            Vector3 movementA = new Vector3(moveHorizontalA, 0, moveVerticalA);

            rb.AddForce(movementA * speed);
        
    }
}
