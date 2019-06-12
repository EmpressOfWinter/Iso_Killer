using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Glass : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;

    public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;


    [Header("UI")]
    public Text countText;
    public Text winText;
    public GameObject Panel;
    private int count;
    

    //FOR ANDROID :
    private float offsetHorizontal;


    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offsetHorizontal = Input.acceleration.x;


        count = 0;
        countText.text = "Count : " + count.ToString();

        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<Collider>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<Collider>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, 0);
        transform.Translate(movement * Time.deltaTime*speed);
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0);

        //rb.AddForce(movement * speed);
        //rb.MovePosition(movement * Time.deltaTime);
#endif


#if UNITY_ANDROID



        float And_moveHorizontal = Input.acceleration.x - offsetHorizontal;

        transform.Translate(And_moveHorizontal, 0, 0);
        

#endif

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        } else if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();

        if (count >= 10)
        {
            winText.enabled = true;
            Panel.SetActive(true);
           
        }
    }



    void LateUpdate()
    {
        if (!Camera.main.orthographic)
        {
            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
            transform.position = viewPos;

        }
        else 
        {

            Vector3 viewPos = transform.position;
            viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
            viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
            transform.position = viewPos;


        }



    }

}
