using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool Joystick_Active = true;
    public Text GUI_Button;

    private GameObject Player_Obj;

    // Start is called before the first frame update
    void Start()
    {
        Player_Obj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Joystick_Active)
        {
            Player_Obj.GetComponent<P_Joystick>().enabled = true;
            Player_Obj.GetComponent<P_Accelerometer>().enabled = false;
            
        }
        else
        {
            Player_Obj.GetComponent<P_Joystick>().enabled = false;
            Player_Obj.GetComponent<P_Accelerometer>().enabled = true;
            
        }
            
    }

    public void GUI_Controls()
    {
#if UNITY_ANDROID

        Joystick_Active = !Joystick_Active;
        GUI_Button.text = Joystick_Active ? "ON" : "OFF";
#endif
    }
}
