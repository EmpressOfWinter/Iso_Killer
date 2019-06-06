using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("CONTROLS")]
    public float speed;
    private Rigidbody rb;

    [Header("UI")]
    public Text countText;
    public Text winText;
    public GameObject Panel;
    private int count;

    //start_Android specifics floats
    private float deltaX, deltaZ;

    //end_Android specifics floats

    void Awake()
    {
        winText.enabled = false;
        Panel.SetActive(false);
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
         
    
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaZ = touchPos.y - transform.position.z;
                    break;

                case TouchPhase.Moved:
                    rb.MovePosition(new Vector3(touchPos.x - deltaX, 0, touchPos.y - deltaZ));
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector3.zero;
                    break;


            }

        }

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
