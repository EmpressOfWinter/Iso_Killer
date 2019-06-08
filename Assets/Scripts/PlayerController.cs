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

    [Header("TIMER")]
    public float timestart;
    public Text TimeDisplay;
    public Text BestTimeDisplay;

    bool timeActive = true;

    void Awake()
    {
        winText.enabled = false;
        Panel.SetActive(false);

    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //SCore settings
        count = 0;
        SetCountText();


        //timer settings
        TimeDisplay.text = "TIME :" + timestart.ToString("F2");
        BestTimeDisplay.text = PlayerPrefs.GetFloat("BestTime", 0).ToString("F2");
    }


    void FixedUpdate()
    {

#if UNITY_EDITOR

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
#endif
        if (timeActive)
        {
            timestart += Time.deltaTime;
            TimeDisplay.text = "TIME :"+ timestart.ToString("F2");

            if (timestart > PlayerPrefs.GetFloat("BestTime", 0))
            {
                PlayerPrefs.SetFloat("BestTime",timestart);
                BestTimeDisplay.text = timestart.ToString("F2");
            }
        }
    }

    //to collect the pick-ups (with trigger colliders)

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count +1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();

        if (count >= 10)
        {
            winText.enabled = true;
            Panel.SetActive(true);
            timeActive = false;
        }
    }

       
    

    //adjust speed function for a slider
    ///public void Adjustspeed(float newSpeed)
    //{
        //speed = newSpeed;
    //}
}
