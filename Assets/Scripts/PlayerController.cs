using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("CONTROLS")]
    public float speed;
    private Rigidbody rb;
    public Joystick joystick;
  

    [Header("UI")]
    public Text countText;
    public Text winText;
    public GameObject Panel;
    private int count;
    public GameObject Joystick_Canvas;

    //start_Android specifics floats
    private float deltaX, deltaZ;

    //end_Android specifics floats

    void Awake()
    {
        winText.enabled = false;
        Panel.SetActive(false);
        Joystick_Canvas.SetActive(false);

#if UNITY_ANDROID

        Joystick_Canvas.SetActive(true);
#endif

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        


    }


    void FixedUpdate()
    {
    #if UNITY_EDITOR
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement*speed);
#endif

#if UNITY_ANDROID


        float moveHorizontalA = joystick.Horizontal;
        float moveVerticalA = joystick.Vertical;

        Vector3 movementA = new Vector3(moveHorizontalA, 0, moveVerticalA);

        rb.AddForce(movementA * speed);

#endif
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();

        if (count >= 12)
        {
            winText.enabled = true;
            Panel.SetActive(true);
        }
    }
}
