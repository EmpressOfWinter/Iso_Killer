using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Accelerometer : MonoBehaviour
{
    [Header("CONTROLS")]
    public float speed;
    private Rigidbody rb;

    

    public GameObject Joystick_Canvas;

    //start_Android specifics floats
    private float deltaX, deltaZ;
    private bool Joystick_Active;

    private float offsetHorizontal;
    private float offsetVertical;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Joystick_Canvas.SetActive(false);

        
    }
    void OnEnable()
    {
        offsetHorizontal = Input.acceleration.x;
        offsetVertical = Input.acceleration.y;
    }

    // Update is called once per frame
    void Update()
    {
        Joystick_Canvas.SetActive(false);


        float And_moveHorizontal = Input.acceleration.x - offsetHorizontal;
        float And_moveVertical = Input.acceleration.y - offsetVertical;

        Vector3 And_tilt = new Vector3(And_moveHorizontal, And_moveVertical, 0);

        And_tilt = Quaternion.Euler(90, 0, 0) * And_tilt;
        

        rb.AddForce(And_tilt * speed);
    }
}
